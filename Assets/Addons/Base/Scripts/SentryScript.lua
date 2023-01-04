function Initialise()
    turretSprite = Entity.GetSpriteComponent("Turret");
    turretSprite.LockRotation(false);
        
end

function Update()

thingy = Input.GetMousePosition();
	RotateTurret();
    

end

function RotateTurret()
    turretSprite.LockRotation(false);
    turretSprite.PointAtPosition(thingy.X, thingy.Y);
    --Entity.Rotate(-0.01);
    MoveTurret();
end

function MoveTurret()
    Entity.Move(0.25, 0);
end
