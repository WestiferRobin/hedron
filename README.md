# Hedron

## Target Platforms
- Web => MuSystem
- PC/macos => local build
- Total: WebGL, Macos, and Windows

## Art References
- https://www.reddit.com/media?url=https%3A%2F%2Fpreview.redd.it%2Fmuz5w4ol34e91.gif%3Fformat%3Dpng8%26s%3Dde66879400cdaf72a9af8309ba3849ce359ccd72
- https://2.bp.blogspot.com/-8-sbv4Zarwo/Vup7KQjQBuI/AAAAAAAADGI/GHRaw5q22D8JLIfeNQI9gQoMk4y5i6PYw/s1600/107-02.jpg
- https://i.pinimg.com/1200x/88/14/25/8814256d2a3e46c30dac00d317e80871.jpg

## Tutorials
- PixelLab Series: https://www.youtube.com/playlist?list=PLqxDfnv9FagPWIQo4Jia8SX5CkFX9iuZ2

## In Progress
- Bugs:
    - Movement
        - Tile selection needs to be polished
            - Player is moving off the tilemap
            - Player and Tile need better collision
- Combat for 2 single Hedrons
    - Ally vs Enemy
            - Ally can be computer or player
            - Enemy can be player
    - Introduce UI Text Hub for Combat
    - Assets
        - Need 5 Ally Races
            - Terrians/Humans are Done
            - TODO:
                - Neptonians/Atlantians/Chiss
                - Venatoans/Twlicks
                - Martians/Zabraks
                - Satourans/Angles
        - Need 5 Enemy Races
            - Zetas/TallGreys are Done
            - TODO:
                - Dathtorians/Demons
                - Reptilians/Egyptians
                - Cybtrons/Robots/Borg
                - Aquarians/Fish/Mon Calamari 
        - Need GameNotes.txt implemented with some assets
            - Include Animations for shooting guns
            - Animations for using Items

## TODOs

### Classic Game
- Socialize for 2 Hedrons
    - Add Social Hub for UI Text Hub
    - Able to Socalize to enemies, accuantices, and best friends
    - Also include a love system for Breeding
        - Work on Gene Algorithm and create families
    - Should also monitor Needs too
    - Assets
        - Create Males and Females
        - Create Children
- AI Integration: Alpha Testing
    - Work with mu-prism with OpenAI
    - Create Tensorflow Models
        - Finish Tensorflow class first
- Maps => 10 maps like valorant
    - Consider Space Update
    - Consider Land Update


### Travel Game
- Beyond Prisms
    - Vehicles
        - Craft (Prism Vehicles)
            - Tanks
            - Speeders
            - Shuttles
            - Fighters
            - Carriers
        - Ships (Hedron Vehicles)
            - Freighter
            - Corvette
            - Frigate
            - Capital
            - Dreadnought
    - Bases
        - Outpost
        - Colony
        - Town
        - City
        - Citadel
    - Solar
        - Remake the solar system
        - Apply Bases and Vehicles
            - Work and make Fortress per Society
            - Create Society Guardian Order
            - Create Society Arch Government
        - Work on Age of Empires and Red Alert mechanics
        - Test 100 v 100 Hedrons
    - Galaxy
        - 3x3x3 Galaxies
            - watch simulation
            - play game
- Board Integration: 100 Hedrons vs 100 Hedrons
    - POLISHING!
        - Update and fix any assets missing including sound
            - Look at PixelLabs
        - Update gamelogic and major refactoring as needed
    - Simulation needs to be the same as if a player does it
        - Speed up version of a player game
    - Camera
        - Make it like Sims and XCOM
    - Board Grid Tests
        - Space Size:
            - Default 10x10
            - Room: 2x2 Grid => 20x20 tiles
            - Hallway: 2x1 and 1x2 Grid => 20x10 and 10x20 tiles
            - Map for a ship
                - Configured
                - Random?
        - Land Size:
            - Tiny: 120x120 tiles
            - Small: 144x144 tiles
            - Medium: 168x168 tiles
            - Normal: 200x200 tiles
            - Large: 220×220 tiles
            - Giant: 240×240 tiles
- Judgement Day: Beta Testing
    - Polish and Test for private Beta
    - Decide to keep as personal or sell it

## Conquest Game
- Apply factions
- Apply resources
- Idea is attonomy and decision for the player
