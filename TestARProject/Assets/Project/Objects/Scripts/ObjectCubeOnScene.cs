namespace TestArProject.Objects
{
    public class ObjectCubeOnScene : AbstractObjectOnScene
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

