using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample
{
    public class StudentDocs
    {
        public Student _student;
        public Dictionary<string, int> _studResults;

        EventHandler<StudentTestEventArgs> lambda;
        Student.StudentTestEvent2 method;



        public StudentDocs(string name, int group)
        {
            _student = new Student(name, group);
            _studResults = new Dictionary<string, int>();
        }

        void Subscribe()
        {
            //Подписка с использованием имени метода
            _student.OnSomeTest += ConsoleInform;
            _student.OnSomeTest += AddResultToDict;

            //Подписка с использованием лямбды
            //Здесь другое событие и другой делегат (просто для примера)
            //_student.OnTest += (object sender, StudentTestEventArgs results)
            //    => _studResults.Add(results.TestName, results.Score);

            ////но здесь не получится отписаться, поэтому используем переменную
            ////переменная объявлена выше
            //lambda = (object sender, StudentTestEventArgs results)
            //    => _studResults.Add(results.TestName, results.Score);
            //_student.OnTest += lambda;
            ////_student.OnTest -= lambda;

            ////Аналогично для анонимного метода
            //method = delegate (string testName, int score)
            //{
            //    Console.WriteLine($"Студент {_student.Name} сдал тест {testName} на {score}");

            //};
            //_student.OnSomeTest2 += method;
            //_student.OnSomeTest2 -= method;
        }

        public void AddTest(string name, int score)
        {
            _student.Test(name, score);
        }

        void ConsoleInform(StudentTestEventArgs results)
        {
            Console.WriteLine($"Студент {_student.Name} сдал тест {results.TestName} на {results.Score}");

        }

        void AddResultToDict(StudentTestEventArgs results)
        {
            _studResults.Add(results.TestName, results.Score);
        }
    }
}
