//write a unit test to check if the priority queue works

namespace Tests{

public class PriorityQueueTests {

    public static void main(string[] args)
    {
        Func<CheckListItem, int> prioritySelector = item => item.Priority;
        PriorityQueue<CheckListItem> pq = new PriorityQueue<CheckListItem>(prioritySelector);

        pq.Enqueue(new CheckListItem("Task 1", new DateTime(2023, 6, 1), 2));
        pq.Enqueue(new CheckListItem("Task 2", new DateTime(2023, 6, 1), 1));
        pq.Enqueue(new CheckListItem("Task 3", new DateTime(2023, 6, 1), 3));

        while (!pq.IsEmpty())
        {
            CheckListItem item = pq.Dequeue();
            Console.WriteLine($"Name: {item.Name}, Priority: {item.Priority}");
        }

    }

}

}