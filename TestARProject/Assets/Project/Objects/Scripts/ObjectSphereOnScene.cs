namespace TestArProject.Objects
{
    public class ObjectSphereOnScene : AbstractObjectOnScene
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

