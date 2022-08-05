## Combat system documentation notes

Every single thing that somehow engages in combat by either attacking, getting hit or both should be registered as a CombatEntity. The combat entity class should be at the topmost GameObject of the given entity, so that all routes of searching through parents will find it. The combat entity gets a unique id on startup, and each hitbox and hurtbox interaction should check for the given ids so as not to hit itself or teammates.

Hitboxes and hurtboxes automatically search through parents for the reference to combat entity.

The data relating to an attack is sent via the AttackData struct. The said data is to be assigned at the hitbox script, so that multiple attacks could be run at the same time. 

TODO: distribute attack ids for each attack and set it in the AttackData struct, so that an attack with multiple hitboxes does not hit multiple times
TODO: record the recent attack ids so as not to get hit by the same attack multiple times