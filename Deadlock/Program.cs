   
    object resource1 = new object();
    object resource2 = new object();

    // Thread 1
    lock (resource1)
    {
        Thread.Sleep(1000);
        lock (resource2)
        {
            // Code execution
        }
    }

    // Thread 2
    lock (resource2)
    {
        Thread.Sleep(1000);
        lock (resource1)
        {
            // Code execution
        }
    }




