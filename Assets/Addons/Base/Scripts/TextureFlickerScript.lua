first = true;

function Initialise()
    square = Entity.GetSpriteComponent("RotateSprite");
end

function Update()
	if(first) then
        square.SetOrigin(32, 32);
        square.SetTexture("Turret");
        first = false
    else
        square.SetOrigin(16, 16);
        square.SetTexture("Square");
        first = true;
    end
end