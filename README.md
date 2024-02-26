# WeaponSystem
A Unity FPS project focused on the weapon system and weapon interactions like attack, reload, aim, refill ammo along with methods for animations, sfx and vfx for each interaction

This system consists of attack, reload, aim, refill ammo for melee, shooting and throwable weapons along with animations, SFX and VFX support from the programming side.
The entire structure of this weapon system consists of a base weapon class that implements interfaces for the functioning of the weapon interactions and various weapon components that implements those interfaces.
The main Melee, Shooting and Throwable class inherits the WeaponBase class. They are ready to extend further based on requirement.

The project implements basic MVC pattern for UI interaction with the weapon system and SOLID principles with the weapons system scripts. 
Free feel to update the code in order to align with MVC and SOLID principles.
