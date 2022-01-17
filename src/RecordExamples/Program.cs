using RecordExamples.CustomerClass;
using RecordExamples.CustomerModifiedClass;
using RecordExamples.CustomerRecord;
using RecordExamples.CustomerRecordIssues;
using RecordExamples.CustomerRecordWithCollection;
using System;

namespace RecordExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerClassTests.Run();
            CustomerModifiedClassTests.Run();
            CustomerRecordTests.Run();
            CustomerRecordIssuesTests.Run();
            CustomerRecordWithCollectionTests.Run();

            Console.ReadLine();
        }
    }
}
