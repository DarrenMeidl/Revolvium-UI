# Revolvium Use Cases 

### w1. Win Level: Door & Key & Rotation
```mermaid
flowchart TD
	A[w1. Win Level: Door and Key and Rotation]
	
	A-->B[w1.1 Explore / View / Observe Level]
	B-->C[w1.1.1 See Unlockable Door]
	C-->D[w1.1.2 See Key]

	A-->E[w1.2 Grab Immediately Available Items]
	E-->F[w1.2.1 Walk / Run to Key]
	F-->G[w1.2.2 Grab / Touch Key]
	G-->H[w1.2.3 Reaction: Door Unlocks / Opens]

	A-->O[w1.3 Rotate Level Rows To Access Door & Goal]
	O-->I[w1.3.1 Walk / Run to Rotation Platform or Button]
	I-->J[w1.3.2 Reaction: Enter Rotation View Mode]
	J-->K[w1.3.3 Select Level Row to Rotate]
	K-->L[w1.3.4 Rotate Row Clockwise Twice]
	L-->M[w1.3.5 Reaction: Door is now on a top-facing Floor Tile]

	A-->P[w1.4 Finish Level]
	P-->Q[w1.4.1 Walk through previously opened Door]
	Q-->R[w1.4.2 Walk to Goal]
	R-->S[w1.4.3 Touch Goal]
	S-->T[w1.4.4 Reaction: Complete Level / Level Ends]
```

### w2. Win Level: Rotation
```mermaid
flowchart TD

A[w2. Win Level: Rotation]

A --> B[w2.1 Explore / View / Observe Level]
B --> C[w2.1.1 See only Goal]

A --> D[w2.2 Rotate Level Rows to Access Goal]
D --> E[w2.2.1 Walk / Run to Rotation Platform or Button]
E --> F[w2.2.2 Reaction: Enter Rotation View Mode]
F --> G[w2.2.3 Select Level Row to Rotate]
G --> H[w2.2.4 Rotate Row Anti-clockwise Once]
H --> I[w2.2.5 Reaction: Player is now on the same plane as the Goal]

A --> J[w2.3 Finish Level]
J --> K[w2.3.1 Walk to Goal]
K --> L[w2.3.2 Touch Goal]
L --> M[w2.3.3 Reaction: Complete Level / Level Ends]
```

### l1. Lose Level: Falling off the Map
```mermaid
flowchart TD
	A[l1. Lose Level: Falling off the Map]
	
	A-->B[l1.1 Explore / View / Observe Level]
	B-->C[l1.1.1 See Unlockable Door]
	C-->D[l1.1.2 See Key]

	A-->E[l1.2 Grab Immediately Available Items]
	E-->F[l1.2.1 Walk / Run to Key]
	F-->G[l1.2.2 Grab / Touch Key]
	G-->H[l1.2.3 Reaction: Door Unlocks / Opens]

	A-->O[l1.3 Attempt to Access Door & Goal]
	O-->I[l1.3.1 Walk / Run to the edge of the Level]
	I-->J[l1.3.2 Keep Walking over the edge, thinking there is Planet-like Gravity\n that will make you Walk on Walls]
	J-->K[l1.3.3 Fall to Death]
	K-->L[l1.3.4 Level Over]
	L-->M[l1.3.5 Choose to Retry Level]
```

---
# Notes from the Enda Class
### Use Cases
Use Cases are different win / lose cases of the game and its mechanics:
- Use Case 1-N: Player wins this way
- Use Case 2-N: Player loses by falling off map
- Use Case 3-B: Player loses this other way by mechanic

### UTSE
Usage Scenarios: Usability
Play Scenarios: Playability

### Specific Interactions
Run, Crawl, Walk, Grab Item, Push Button, Orientation (Figuring out Direction), Activate.
The player has to be engaged and understand.

### B / M / E
Stages of the Use Case: Begin / Middle / End.

### UCD
User-Centred Design like UX Profiles (Now HCD Human-Centred Design, PCD is specific Person-Centred Design like UX Personas).

### UD Principles
There's 7 principles
Size + Physical Space to Use
Physical Effort Exerted
Design for the Extreme Ends of Users
Innovation happens in the extremes

### GPF
Gameplay Features

### MoSCoW
Highly Prioritised Feature List
-> Mechanic: Do this first; Player Movement, Level Orienting
-> Control: Start with WASD, Arrows; Then specify the real controls in the game, all specific interactions a player can do; What's in their toolbelt / what's on their mind to use.
-> Collision Detection / Collision Reaction
-> Model / Level Design / Texture / Lighting
-> Sound
-> Score / Health / Time / State Variables
-> Win + Lose

![[Pasted image 20241002123249.png]]
