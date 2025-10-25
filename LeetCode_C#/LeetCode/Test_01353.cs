
namespace TestProject1
{
    internal class Test_01353
    {
        internal int MaxEvents(int[][] events)
        {
            Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

            var pq = new PriorityQueue<int, int>();
            int attendedCount = 0;
            int eventIndex = 0;
            int n = events.Length;

            int maxDay = 0;
            foreach(var e in events)
            {
                maxDay = Math.Max(maxDay, e[1]);
            }

            for(int day = 1; day <= maxDay; day++)
            {
                while(eventIndex < n && events[eventIndex][0] == day)
                {
                    pq.Enqueue(events[eventIndex][1], events[eventIndex][1]);
                    eventIndex++;
                }

                while(pq.Count > 0 && pq.Peek() < day)
                {
                    pq.Dequeue();
                }

                if(pq.Count > 0)
                {
                    attendedCount++;
                    pq.Dequeue();
                }
            }
            return attendedCount;
        }
    }
}