using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudyBee.EntitySystem;
using CloudyBee.EntitySystem.Components;
using Microsoft.Xna.Framework;

namespace CloudyBeeTests
{
    [TestClass]
    public class ComponentTests
    {
        private const string TEST_COMPONENT_NAME = "TestComponent";

        [TestMethod]
        public void HasComponentTest()
        {
            Entity testEntity = GetTestEntity();

            Assert.IsTrue(testEntity.HasComponent<TestComponent>());
        }

        [TestMethod]
        public void AddComponentTest()
        {
            Entity entity = new Entity();
            TestComponent componentTest = new TestComponent(TEST_COMPONENT_NAME, new Vector2(0, 0));

            entity.AddComponent(componentTest);

            Assert.IsTrue(entity.HasComponent<TestComponent>());
        }

        [TestMethod]
        public void GetComponentByTypeTest()
        {
            Entity testEntity = GetTestEntity();

            TestComponent component = testEntity.GetComponent<TestComponent>();

            Assert.IsNotNull(component);
        }

        [TestMethod]
        public void GetComponentByNameTest()
        {
            Entity testEntity = GetTestEntity();

            TestComponent component = testEntity.GetComponent<TestComponent>(TEST_COMPONENT_NAME);

            Assert.AreEqual(component.Name, TEST_COMPONENT_NAME);
        }

 
        private Entity GetTestEntity()
        {
            TestComponent testComponent = new TestComponent(TEST_COMPONENT_NAME, new Vector2(0,0));
            Entity testEntity = new Entity();
            testEntity.AddComponent(testComponent);


            return testEntity;
        }
    }

    class TestComponent : Component
    {
        public TestComponent(string name, Vector2 offSet) : base(name, offSet)
        {
        }
    }
}
