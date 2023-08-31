# Game Engine 2 Assignment

## Assnigment requirements：

In this assignment, we will create a game that simulates the emergence of artificial life. The goal is to explore how simple rules and interactions between individual agents can give rise to complex and unpredictable behaviors at a system level.

To tie in the themes of John Conway, Alan Watts, Terence McKenna, Maths, and the Universe, you will be asked to incorporate the following elements:

Alan Watts: Consider how the concept of "wu-wei" (effortless action) can be applied to the behavior of the artificial life forms in your game. Can you create agents that exhibit emergent behaviors without needing to be explicitly programmed for them?

Terence McKenna: Use the concept of "novelty" to guide your approach to designing the rules and behaviors of the artificial life forms. How can you create a system that is always evolving and adapting to new challenges and opportunities?

Mathematics: Explore how mathematical concepts like chaos theory, fractals, cellular automata and boids can be used to model the behavior of the artificial life forms. Consider how different mathematical models can lead to different emergent behaviors.

The Universe: Think about how the behavior of the artificial life forms in your game relates to larger patterns and structures in the natural world. How can you create a system that reflects the complexity and interconnectedness of the universe?

## Project describe:

A 3d game project:

I designed three artificial lives:  
1. Artificial small fish:  
Automatic random generation  
Follow the boids model to gather, move and avoid obstacles.  
According to the hunger value, it will leave the shoal of fish to prey on seaweed, and the hunger value is 35-50 random seconds.  
After each meal, feces are excreted at random events.  
After preying on seaweed for 5 times, it becomes an artificial big fish.  
Death when hunger value is 0.  

2. Artificial big fish:  
Artificial small fish preyed on artificial seaweed for 5 times and became artificial big fish.  
Follow the boids model to move and avoid obstacles.  
According to the hunger value, it will leave the shoal of fish to prey on small fish, and the hunger value is 35-50 random seconds.  
Death occurs when the hunger value is 0.  

3. Artificial seaweed:  
Automatic random generation 
Can be eaten by small fish for 5 times  
Replenishment to feces can add 5 times to be eaten.  

4. Players can move the observation by moving the mouse and clicking the wasd key.  

You can directly change various data in the code file, such as the number and time of fish generation.  

Difficulties and errors encountered and solved:  
Small fish and big fish switch.  
What will fish do if food is eaten by others during predation?  
How to calculate the new boid group without reporting errors.  
The Boid logic may appear too close to the border and swim out directly.  

Problems that still exist:  
Two fish will twitch when they hit each other for prey food.  
