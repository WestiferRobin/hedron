using System;
using UnityEngine;

public class Prism : MonoBehaviour
{
    public Guid Id { get; private set; }
    public PrismBody Body { get; private set; }
    public PrismStats Stats { get; private set; }
    public PrismGender Gender { get; private set; }
    public PrismName Name { get; private set; }

    private Color primaryColor;
    private Color secondaryColor;
    private Color selectorColor = Color.yellow;

    private Vector3 targetTilePosition;
    private bool isMoving = false;

    #region Unity Methods
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isMoving)
            {
                // Check if the click hits a valid tile (you may need to implement this logic)
                if (TrySelectTile(out targetTilePosition))
                {
                    // Set the move flag to true
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            // Calculate and perform Prism movement logic here
            Move(targetTilePosition);
        }
    }

    private bool TrySelectTile(out Vector3 tilePosition)
    {
        tilePosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Tile tile = hit.collider.GetComponent<Tile>();
            if (tile != null)
            {
                tilePosition = tile.transform.position;
                return true;
            }
        }

        return false;
    }

    public void Start()
    {
        Renderer myRenderer = GetComponent<Renderer>();

        if (myRenderer != null)
        {
            Material primary = myRenderer.materials[0];
            primaryColor = primary.color;
            Material secondary = myRenderer.materials[1];
            secondaryColor = secondary.color;
            var childrenSize = this.transform.childCount;
            for (int i = 0; i < childrenSize; i++)
            {
                var child = this.transform.GetChild(i);
                var childRenderer = child.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    if (child.name.ToUpper().Contains("SPHERE"))
                    {
                        childRenderer.material = secondary;
                    }
                    else
                    {
                        childRenderer.material = primary;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Renderer component not found on this GameObject.");
        }
        this.InitalizePrism();
    }

    public void OnMouseDown()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        if (myRenderer != null )
        {
            myRenderer.materials[0].color = selectorColor;
            myRenderer.materials[1].color = selectorColor;
        }
    }

    public void OnMouseUp()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        if ( myRenderer != null )
        {
            myRenderer.materials[0].color = primaryColor;
            myRenderer.materials[1].color = secondaryColor;
        }
    }

    public void InitalizePrism(PrismName name = null, PrismGender gender = PrismGender.Unknown, PrismStats stats = null)
    {
        this.Id = Guid.NewGuid();

        this.Body = new PrismBody();

        stats ??= new DefaultIdentity();
        this.Stats = stats;

        if (gender == PrismGender.Unknown)
        {
            gender = PrismGenderHelper.RandomPrismGender();
        }
        this.Gender = gender;

        if (name == null)
        {
            string firstName = PrismNameGenerator.RandomFirstName(Gender);
            string lastName = PrismNameGenerator.RandomLastName();
            this.Name = new PrismName(firstName, lastName);
            this.transform.name = this.Name.FullName;
        }
        else
        {
            this.Name = name;
        }
    }
    #endregion

    #region Aux Methods
    public bool Equals(Prism other)
    {
        if (other == null)
            return false;

        return other.Id == Id;
    }

    public override string ToString()
    {
        string str = $"Name: {Name}\n";
        str += $"Gender: {Gender}\n";
        str += $"Position: {this.transform.position}\n";
        str += $"Body: {Body}\n";
        return str;
    }
    #endregion

    #region Combat Methods
    public void ApplyDamage(int damage, BodyPart part)
    {
        if (Body.BodyParts.ContainsKey(part))
        {
            int bodyDamage = Body.BodyParts[part] - damage;
            if (bodyDamage <= 0)
                Body.BodyParts.Remove(part);
            else
                Body.BodyParts[part] = bodyDamage;
        }
    }

    public bool IsDamaged()
    {
        return Body.IsDamaged();
    }

    public bool CanFight()
    {
        return Body.BodyParts.ContainsKey(BodyPart.Arms) && CanMove() && IsAlive();
    }

    public void Fight(Prism target)
    {
        if (!CanFight())
            return;
        if (!InRange(target, maxRange: 1))
            return;
        Body.Fight(target);
    }
    #endregion

    #region Movement Methods
    public bool CanMove()
    {
        return Body.BodyParts.ContainsKey(BodyPart.Legs);
    }

    public void Move(Vector3 targetPosition)
    {
        // Calculate the distance between current and target positions
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Move the Prism towards the target tile
        float moveSpeed = 5f; // Adjust the speed as needed
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the Prism has reached the target tile
        if (distance < 0.1f)
        {
            // Reset the move flag
            isMoving = false;
        }
    }

    public void Move()
    {
        int scaler = UnityEngine.Random.Range(1, 4);
        int x = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.x;
        int z = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.z;
        var position = new Vector3((int)x, 0, (int)z);
        Move(position);
    }

    public bool InRange(Prism target, float maxRange = 3)
    {
        float xDiff = target.transform.position.x - this.transform.position.x;
        float yDiff = target.transform.position.y - this.transform.position.y;

        // Calculate the Euclidean distance
        float distance = Mathf.Sqrt(xDiff * xDiff + yDiff * yDiff);

        // Check if the distance is within the specified range
        return distance <= maxRange;
    }
    #endregion

    #region Health Methods
    public bool IsAlive()
    {
        if (Body.BodyParts.Count <= 0)
            return false;
        if (!Body.BodyParts.ContainsKey(BodyPart.Head))
            return false;
        if (!Body.BodyParts.ContainsKey(BodyPart.Torso))
            return false;
        return true;
    }

    public void Rest()
    {
        Body = new PrismBody();
    }
    #endregion

    #region Social Methods
    public void Socialize(Prism otherPrism)
    {
        // brig myers
        // https://www.dreamsaroundtheworld.com/wp-content/uploads/2021/04/Screenshot-2021-04-06-at-11.36.40.png
        // keep a dictionary of relationships with user
    }

    public void Breed(Prism parent, bool isRandom = false)
    {
        // this should be this.Body.breed(parent.Body)
        // IN THERE it should doing the gene algro
        // THEN append and create a family
        // again it makes sense for the body and social relations
    }
    #endregion
}