# LEVEL CREATION

- Add level blocks to the level object. They will use this objects transform as the [Level Core](Terminology.md#terminology)
- Then they need to be added into the [Level Creation Behaviour](Terminology.md#scripts). The order does matter, since this determines how they are placed. A creation setting object is required to.
- The order of placement is as follows, assuming you have the camera facing in the positive X direction.
    - It will start on the bottom right on the nearest side.
    - Next it will stay on the bottom and move left until the size of the level has been reached.
    - It will move to the next layer up and the the far right.
    - It will move left until it reaches the size of the level.
    - Repeat until all blocks are placed