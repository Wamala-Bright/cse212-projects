using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Week02.Code
{
    [TestClass]
    public class PriorityQueue_Tests
    {
        /*
         Test Result:
         - Initial test failed.
         - Error: Dequeue did not return the highest priority item.
         - Fix: Dequeue logic updated to select the item with the highest priority.
        */
        [TestMethod]
        public void Dequeue_ReturnsHighestPriority()
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Enqueue("Low", 1);
            queue.Enqueue("High", 5);
            queue.Enqueue("Medium", 3);

            string result = queue.Dequeue();

            Assert.AreEqual("High", result);
        }

        /*
         Test Result:
         - Initial test failed.
         - Error: Queue did not preserve FIFO order for same priority items.
         - Fix: Dequeue now removes the earliest enqueued item when priorities match.
        */
        [TestMethod]
        public void Dequeue_SamePriority_FollowsFIFO()
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Enqueue("First", 3);
            queue.Enqueue("Second", 3);
            queue.Enqueue("Third", 3);

            string result = queue.Dequeue();

            Assert.AreEqual("First", result);
        }

        /*
         Test Result:
         - Initial test failed.
         - Error: Items were removed in insertion order instead of by priority.
         - Fix: Dequeue scans entire queue for highest priority.
        */
        [TestMethod]
        public void Dequeue_MixedPriorities_ReturnsCorrectOrder()
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Enqueue("A", 2);
            queue.Enqueue("B", 5);
            queue.Enqueue("C", 1);
            queue.Enqueue("D", 5);

            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("D", queue.Dequeue());
            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual("C", queue.Dequeue());
        }

        /*
         Test Result:
         - Initial test failed.
         - Error: Dequeue did not throw an exception on empty queue.
         - Fix: Added InvalidOperationException when queue is empty.
        */
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Dequeue();
        }

        /*
         Test Result:
         - Initial test failed.
         - Error: Exception message did not match required text.
         - Fix: Updated exception message to exactly "The queue is empty."
        */
        [TestMethod]
        public void Dequeue_EmptyQueue_ExceptionMessageCorrect()
        {
            PriorityQueue queue = new PriorityQueue();

            try
            {
                queue.Dequeue();
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The queue is empty.", ex.Message);
            }
        }
    }
}