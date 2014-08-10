Quick Draw

---

Rules:

For each trial, you will be shown a target for a couple seconds,
followed by 6 targets appearing for two seconds one after another.
Press space as fast as you can when you spot the target color
target, but do not press it if you don't see it in the 6 targets.
You may correct your answer and press space as many times as you
want, but it will affect your end rating.

At the end of all of the trials, you will be given various stats 
on how accurate you were and how long it took to recognize targets.

To start, you must press select the number of trials you want by
clicking on the up/down arrows and then pressing the Start button
on the main menu.

---

Organization:

The project is organized in the following hierarchy:

Assets
	Art
		Sprites
	Audio
	Prefabs
	Scenes
	Scripts

The Art->Sprite folder contains background, button, and target
sprites. The Scripts folder contains all scripts, including
Button, ButtonAction and associated subclasses, TrialManager,
Trial, and Stats. The Prefabs folder contains a Trial prefab
used by the Trial Manager, and the Scenes folder contains
and Init scene for game setup, MainMenu scene, Trials scene,
and Results scene. There is currently no audio in the game.

---

Code:

Buttons use a simple and modular setup to allow many different
actions. Button attaches to any gameobject and will run when
it is clicked on if it has some collider. It is given a
ButtonAction and run's it's action when clicked. ButtonAction
is an abstract class that can be redefined for any purpose,
such as iterating Trial numbers, starting trials,
and going back to the main menu.

The trial manager manages the active scene, setting up
trials to run, running the trials in order, and triggering
results to be calculated. It keeps an active list of trials
so they may be checked later.

Each trial has settings such as what the target should be, 
how many other targets to show in the trial, and what colors
are allowable. When told to setup by the trial manager, it
selects which color targets will go where in the sequence
and whether or not the target color will appear and where.
It has a coroutine to run the trial itself with the given
time intervals.

The Stats runs when instructed by the trial manager and uses
the list of completed trials to score accuracy and time taken.
Here is the detailed list of stats displayed:

	Trials:
	Length of each Trial:
	Targets correct:
	Targets Incorrect:
	Targets Missed:
	Average # of shots per trial:
	Average time per trial:
	Rating:

The Rating stat is a textual feedback that comes in three parts.
It first tells you how accurate you were, then how sure of your
shot you were (based on average shots per trial), and then
how quick your fingers were (based on average time per trial).

---

Scoring:

See the previous section for how scoring takes place.

For the Rating stat, the values that change the text you receive
for each aspect were selected by me.

---

Interesting/Useful Information:

I decided not to focus much on the art and audio, although I did
give making something that involves more of them a thought. I just
didn't want to take much longer with submitting the test.

For art, however, I did choose purposefully to use grayscale sprites
because I knew I could simply change the color in Unity, which saved
on memory.