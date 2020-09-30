using Elevator_ConsoleApp_NetCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elevator_UnitTests
{
    [TestClass]
    public class ElevatorTests
    {
        private Elevator _elevator;
        private int floors = 10;

        [TestMethod]
        public void ElevatorTests_CanInitializeElevator()
        {
            //Act
            var elevator = new Elevator(floors);
            
            //Assert
            Assert.IsNotNull(elevator);
            Assert.AreEqual(floors, elevator.MaxFloor);
        }

        [TestMethod]
        public void ElevatorTests_FloorExists_True()
        {
            //Arrange
            int floor = 1;
            _elevator = new Elevator(floors);

            //Act
            var result = _elevator.FloorExists(floor);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ElevatorTests_FloorExists_False()
        {
            //Arrange
            int floor = 11;
            _elevator = new Elevator(floors);

            //Act
            var result = _elevator.FloorExists(floor);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ElevatorTests_GoToFloor_Sets_IsCurrentFloor()
        {
            //Arrange
            int floor = 5;
            _elevator = new Elevator(floors);

            //Act
            _elevator.GoToFloor(floor);
            var result = _elevator.IsCurrentFloor(floor);

            //Assert
            Assert.IsTrue(result);
        }
    }
}