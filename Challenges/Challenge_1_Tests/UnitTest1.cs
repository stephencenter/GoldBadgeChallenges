using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_1;

namespace Challenge_1_Tests {

    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void MethodRepository_AddMenuItem_ShouldGiveCorrectCount() {
            // Arrange
            MenuRepository mrep = new MenuRepository();
            MenuItem menu_item = new MenuItem();
            int old_count = mrep.GetList().Count;
            mrep.AddMenuItem(menu_item);

            // Act
            var actual = mrep.GetList().Count;
            var expected = old_count + 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MethodRepository_RemoveMenuItem_ShouldGiveCorrectCount() {
            // Arrange
            MenuRepository mrep = new MenuRepository();
            MenuItem menu_item = new MenuItem();
            MenuItem menu_item2 = new MenuItem();
            MenuItem menu_item3 = new MenuItem();

            mrep.AddMenuItem(menu_item);
            mrep.AddMenuItem(menu_item2);
            mrep.AddMenuItem(menu_item3);

            int old_count = mrep.GetList().Count;
            mrep.RemoveMenuItem(mrep.GetList()[-1]);

            // Act
            var actual = mrep.GetList().Count;
            var expected = old_count - 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
