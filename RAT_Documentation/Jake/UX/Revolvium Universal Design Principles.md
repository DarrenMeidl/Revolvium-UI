# Main UDP: Simple & Intuitive
Players will be able to see what rotation move they will perform, regardless of whether they know how a Rubik's cube works.

How we will do this:
- Minimal "Platforming" gameplay, at most a direction input and a button may be pressed (No more than 2 inputs at once will ever be needed in a puzzle), this will be tested with users for feedback and tweaking. This is a puzzle game first, not a platformer.
- Puzzles are never related to tight timing, there will be no strain / hard inputs to perform to succeed.
- Rotation mechanics will be tested to be as intuitive to the players as possible, there are proposed control schemes (on controller is the focus, as this has less mapping options, keyboard can mimic it easily due to the layout).
- Rotation mechanics will have very obvious and useful graphics to show you what will happen if you do the action (will be user tested), large arrows that will dynamically move to what you're going to do.
- The same button (on controller & keyboard) CAN have multiple uses / different actions, but these will attempt to be mentally separated for the player, as they will swap to completely different camera angles for each gameplay section:
	- Player Movement: 3rd Person over-the-shoulder for moving the player about the level.
	- Level Rotation: Wide Isometric view of the entire level, where the player is visible but the whole level is the bigger / more important focus.
# Secondary UDP: Low Physical Effort
Players will be able to beat the level when understood, regardless of physical capability.

How we will do this:
- No more than 2 buttons (maybe we won't even have jumping? NEEDS DISCUSSION WITH LEVEL DESIGN & MECHANICS DEPT.) / inputs will need to be pressed at once.
- There is no time-bound interactions, the player will never need to rush, they can take all the time they need to finish. This is a puzzle game, so thinking and experimentation is encouraged.
# How these Principles will affect our Game
- The level design must stay grounded, not much jumping (Or any?).
- There must be no timing involved to solve a puzzle.
- The interactable objects in a level must be obvious and stand out clearly from the environment.
- The rotation mechanics must be explained clearly, and always have guides / information on screen for what action you are about to perform.

---
# All the other ones (not priority)
### Perceptible
- Player's Position is displayed via wall-shadows (outline of player visible through walls).
- The interactable entities in the level are obvious and stand out from the environment / non-interactable objects.
### Flexible
- Due to the main rotation mechanic, there may be more than one "path" / way to complete a level / puzzle, but there will always be one intended way.
### Physical Accessibility
- Multiple Control Schemes.
	- Keyboard
	- Controller
### Tolerance for Error
- Player cannot jump off the level, there is no death / resetting the level by error, only by choice of hitting the "reset" button
### Flexible
- Multiple control schemes, on the same device.
	- Remappable controls?
