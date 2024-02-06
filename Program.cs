//Thread
void func1() { for (int i = 0; i < 1; i++) Console.WriteLine("Doing func1"); }
void func2() { for (int i = 0; i < 2; i++) Console.WriteLine("Doing func2"); }
void func3() { for (int i = 0; i < 3; i++) Console.WriteLine("Doing func3"); }

void threadDemo() {
    Console.WriteLine("Thread Demo");
    Thread thread1 = new Thread(new ThreadStart(func1));
    Thread thread2 = new Thread(new ThreadStart(func2));
    Thread thread3 = new Thread(new ThreadStart(func3));
    thread1.Start();
    thread2.Start();
    thread3.Start();
}

//Async-Await
Task task1 = Task.Factory.StartNew(() => func1());
Task task2 = Task.Factory.StartNew(() => func2());
Task task3 = Task.Factory.StartNew(() => func3());

async void asyncDemo() {
    Console.WriteLine("Async Await Demo");
    await task1;
    await task2;
    await task3;
}

//main
threadDemo();
asyncDemo();
