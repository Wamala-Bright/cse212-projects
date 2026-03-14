using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of doubles with size equal to 'length'.
        // 2. Use a loop to go through each index of the array.
        // 3. For each position i, calculate the multiple as number * (i + 1).
        // 4. Store the calculated value in the array.
        // 5. Return the array after it has been filled.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// </summary>
  public static void RotateListRight(List<int> data, int amount)
{
    // PLAN:
    // 1. Determine where to split the list so that the last 'amount' elements
    //    can be moved to the front of the list.
    // 2. Copy the last 'amount' elements into a temporary list.
    // 3. Copy the remaining elements at the beginning of the list into another list.
    // 4. Clear the original list so it can be rebuilt.
    // 5. Add the elements that were at the end first.
    // 6. Add the elements that were originally at the beginning after.

    // Step 1: Calculate the index where the split will occur
    int splitIndex = data.Count - amount;

    // Step 2: Get the elements that will move to the front
    List<int> rightPart = data.GetRange(splitIndex, amount);

    // Step 3: Get the elements that will move to the back
    List<int> leftPart = data.GetRange(0, splitIndex);

    // Step 4: Clear the original list
    data.Clear();

    // Step 5: Add the right-side elements first
    data.AddRange(rightPart);

    // Step 6: Add the left-side elements after
    data.AddRange(leftPart);
}
}