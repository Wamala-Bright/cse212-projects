using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Week02.Code
{
    [TestClass]
    public class TakingTurnsQueue_Tests
    {
        /*
         Test Result:
         - Initially failed for infinite turns.
         - Error: Person with Turns <= 0 was not re-added to the queue.
         - Fix: Updated GetNextPerson to re-enqueue when Turns <= 0.
        */
        [TestMethod]
        public void InfiniteTurnsPerson_ReEnqueued()
        {
            var queue = new TakingTurnsQueue();
            queue.AddPerson("Alice", 0);

            // First dequeue
            Person first = queue.GetNextPerson();
            Assert.AreEqual("Alice", first.Name);

            // Alice should still be in the queue (infinite turns)
            Person second = queue.GetNextPerson();
            Assert.AreEqual("Alice", second.Name);
        }

        /*
         Test Result:
         - Initially failed for finite turns.
         - Error: Person with 2 turns was re-enqueued incorrectly.
         - Fix: Decremented Turns correctly and re-added only if Turns > 0.
        */
        [TestMethod]
        public void FiniteTurnsPerson_DecrementedAndReEnqueued()
        {
            var queue = new TakingTurnsQueue();
            queue.AddPerson("Bob", 2);

            // First dequeue, Bob has 2 turns → should be re-added
            Person first = queue.GetNextPerson();
            Assert.AreEqual("Bob", first.Name);

            // Second dequeue, Bob now has 1 turn → still re-added?
            Person second = queue.GetNextPerson();
            Assert.AreEqual("Bob", second.Name);

            // Third dequeue, Bob now has 0 turns → should NOT be re-added
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                queue.GetNextPerson();
            });
        }

        /*
         Test Result:
         - Initially failed for empty queue exception.
         - Error: Did not throw exception or message was wrong.
         - Fix: Added InvalidOperationException with message "The queue is empty."
        */
        [TestMethod]
        public void DequeueEmptyQueue_ThrowsException()
        {
            var queue = new TakingTurnsQueue();

            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                queue.GetNextPerson();
            });

            Assert.AreEqual("The queue is empty.", ex.Message);
        }

        /*
         Test Result:
         - Initially failed for multiple people circular behavior.
         - Error: People not properly re-enqueued in order.
         - Fix: Dequeue returns front and re-adds according to Turns rules.
        */
        [TestMethod]
        public void MultiplePeople_CircularBehavior()
        {
            var queue = new TakingTurnsQueue();
            queue.AddPerson("Alice", 1);
            queue.AddPerson("Bob", 2);

            // First dequeue → Alice (1 turn) → removed from queue
            Person first = queue.GetNextPerson();
            Assert.AreEqual("Alice", first.Name);

            // Second dequeue → Bob (2 turns) → re-added
            Person second = queue.GetNextPerson();
            Assert.AreEqual("Bob", second.Name);

            // Third dequeue → Bob again (1 turn) → re-added
            Person third = queue.GetNextPerson();
            Assert.AreEqual("Bob", third.Name);

            // Queue should now be empty
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                queue.GetNextPerson();
            });
        }
    }
}