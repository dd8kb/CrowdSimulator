Crowd Simulation is written with sugar, spice and everything nice
=================================================================
The basic idea was to create a simple simulation of people walking around. The next step was to implement different types of people. We limited ourselves to the following four types: Normal, Murderer, Victim and Dead. These types differ from each other in the way they move (obviously, dead people don't walk around) and in the way they take decisions.

Implementation
---------------
With the implementation style we used in our program, we wanted to keep it simple to add more decision and movement behaviours. Therefore we were in need to make use of the strategy pattern. So we are also able to change the behaviour and the movement of single people during runtime.
	//Set the MovementBehaviour
	Human.MovementBehaviour = new EvadeMovementBehaviour();
Also we thought about using the factory pattern to avoid too much of duplicated code.
	//Make use of Factory
	Human temp = humanFactory.CreateHuman();

Next Steps
----------
As a next step we could imagine to add the ability of taking advantage of multicore processing. To take the program to the level of a masterpiece, we intend to change the view. To display the people in real 3D.
