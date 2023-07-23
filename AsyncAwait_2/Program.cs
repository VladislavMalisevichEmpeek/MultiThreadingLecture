using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsyncAwaitDecompile
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(string.Format("Main method started in thread {0}.", (object)Thread.CurrentThread.ManagedThreadId));
            Program.WriteCharAsync('#');
            Program.WriteChar('*');
            Console.WriteLine(string.Format("Main method finished in thread {0}.", (object)Thread.CurrentThread.ManagedThreadId));
            Console.ReadKey();
        }

        private static void WriteChar(char symbol)
        {
            Thread.Sleep(500);
            for (int index = 0; index < 80; ++index)
            {
                Console.Write(symbol);
                Thread.Sleep(100);
            }
        }

        [AsyncStateMachine(typeof(Program.WriteCharAsyncStruct))]
        private static Task WriteCharAsync(char symbol)
        {
            // Create an instance of the state machine
            Program.WriteCharAsyncStruct stateMachine = default;

            // Fill the fields of the state machine
            stateMachine.symbol = symbol;
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;

            // Start the state machine (inside the MoveNext method call)
            stateMachine.builder.Start<Program.WriteCharAsyncStruct>(ref stateMachine);
            return stateMachine.builder.Task;
        }


        public Program()
            : base()
        {
        }

        /// <summary>
        /// Class representing the lambda expression () => WriteChar(symbol)
        /// </summary>
        [CompilerGenerated]
        private sealed class DisplayClass
        {
            /// <summary>
            /// Captured parameter in the lambda expression.
            /// </summary>
            public char symbol;

            public DisplayClass()
                : base()
            {

            }

            /// <summary>
            /// Body of the lambda expression.
            /// </summary>
            internal void WriteCharAsync()
            {
                Program.WriteChar(this.symbol);
            }
        }

        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        private struct WriteCharAsyncStruct : IAsyncStateMachine
        {
            // Public fields of the state machine to be filled upon instantiation.
            public int state;
            public AsyncTaskMethodBuilder builder;
            public char symbol;

            // Private fields of the state machine to store the values of local variables when suspended.
            private TaskAwaiter awaiter;

            /// <summary>
            /// Method that performs the body of the async method. Changes the state of the state machine upon each step.
            /// </summary>
            void IAsyncStateMachine.MoveNext()
            {
                // Get the state of the state machine from the state field.
                int num1 = this.state;
                try
                {
                    // Create a task awaiter for the completion of the async task
                    TaskAwaiter awaiter;
                    if (num1 != 0)
                    {
                        // Create an instance of the class representing the lambda expression: () => WriteChar(symbol).
                        DisplayClass displayClass = new DisplayClass();
                        displayClass.symbol = this.symbol;
                        Console.WriteLine(string.Format("WriteCharAsync method started in thread {0}.", (object)Thread.CurrentThread.ManagedThreadId));

                        // Working with the await operator:
                        awaiter = Task.Run(new Action(displayClass.WriteCharAsync)).GetAwaiter();
                        // Check if the task has completed.
                        if (!awaiter.IsCompleted)
                        {
                            // Set the state of the state machine to waiting.
                            // Any value other than "-1" and "-2" indicates that the state machine is waiting for the completion
                            // of an asynchronous operation.
                            this.state = 0;
                            this.awaiter = awaiter;
                            // The method will create and set the continuation for the async task.
                            this.builder.AwaitUnsafeOnCompleted<TaskAwaiter, Program.WriteCharAsyncStruct>(ref awaiter, ref this);
                            // Return control to the "calling thread".
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.awaiter;
                        this.awaiter = new TaskAwaiter();
                        // A value of "-1" for the state also indicates that the state machine is running.
                        this.state = -1;
                    }
                    // Complete the waiting for the async task.
                    awaiter.GetResult();
                    Console.WriteLine(string.Format("WriteCharAsync method finished in thread {0}.", (object)Thread.CurrentThread.ManagedThreadId));
                }
                catch (Exception ex)
                {
                    // Setting the value "-2" for the state of the state machine indicates that it has finished its work.
                    this.state = -2;
                    // Setting the received exception to the dummy task
                    this.builder.SetException(ex);
                    return;
                }
                // Setting the value "-2" for the state of the state machine indicates that it has finished its work.
                this.state = -2;
                // Setting the successful completion of the dummy task
                this.builder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.builder.SetStateMachine(stateMachine);
            }
        }
    }
}
