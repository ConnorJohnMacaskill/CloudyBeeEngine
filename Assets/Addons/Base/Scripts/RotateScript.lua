function Initialise()
    square = Entity.GetSpriteComponent("RotateSprite");
    turret = Entity.GetSpriteComponent("DifferentSprite");
end

function Update()
	Rotate();
end

function Rotate()
    --Entity.Rotate(0.01);
    turret.Rotate(0.04);
end