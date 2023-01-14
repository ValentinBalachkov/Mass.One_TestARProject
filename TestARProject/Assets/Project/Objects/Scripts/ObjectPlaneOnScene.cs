namespace TestArProject.Objects
{
    public class ObjectPlaneOnScene : AbstractObjectOnScene
    {
        public override void SetRandomColor()
        {
            _material.color = GetRandomColor();
        }

        public override void SetOutline()
        {
            
        }
    }
}

