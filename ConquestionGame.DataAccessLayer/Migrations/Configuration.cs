namespace ConquestionGame.DataAccessLayer.Migrations
{
    using ConquestionGame.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConquestionGame.DataAccessLayer.ConquestionDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ConquestionGame.DataAccessLayer.ConquestionDBContext context)
        {
            bool exists = context.QuestionSets.Any(x => x.Id == 1);
            //  This method will be called after migrating to the latest version.
            if (!exists)
            {
                context.QuestionSets.AddOrUpdate(InitializeData());
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        public QuestionSet InitializeData()
        {
            QuestionSet qs = MakeQuestionSet("CS", "Computer science questions");

            Question q1 = MakeQuestion("What does HTML stand for?", qs);
            Answer q1a1 = MakeAnswer(false, "Hypertext Meta Language");
            Answer q1a2 = MakeAnswer(true, "Hypertext Markup Language");
            Answer q1a3 = MakeAnswer(false, "Hypertext Meat Language");
            Answer q1a4 = MakeAnswer(false, "Hypertext Meta Linguistics");
            AddAnswersToQuestion(q1, q1a1, q1a2, q1a3, q1a4);

            Question q2 = MakeQuestion("What does TCP stand for?", qs);
            Answer q2a1 = MakeAnswer(true, "Transmission Control Protocol");
            Answer q2a2 = MakeAnswer(false, "Transaction Control Protocol");
            Answer q2a3 = MakeAnswer(false, "Taco Control Protocol");
            Answer q2a4 = MakeAnswer(false, "Text Conversion Process");
            AddAnswersToQuestion(q2, q2a1, q2a2, q2a3, q2a4);

            Question q3 = MakeQuestion("What does ABC stand for in WCF endpoint?", qs);
            Answer q3a1 = MakeAnswer(false, "Address Bank Contract");
            Answer q3a2 = MakeAnswer(false, "Anonymous Binding Contract");
            Answer q3a3 = MakeAnswer(false, "Answer Binding Contact");
            Answer q3a4 = MakeAnswer(true, "Address Binding Contract");
            AddAnswersToQuestion(q3, q3a1, q3a2, q3a3, q3a4);

            Question q4 = MakeQuestion("What does XML stand for?", qs);
            Answer q4a1 = MakeAnswer(false, "Xtreme Modeling Language");
            Answer q4a2 = MakeAnswer(true, "Extensible Markup Language");
            Answer q4a3 = MakeAnswer(false, "Expandable Meta Language");
            Answer q4a4 = MakeAnswer(false, "Extensible Messaging Language");
            AddAnswersToQuestion(q4, q4a1, q4a2, q4a3, q4a4);

            Question q5 = MakeQuestion("What are the four layers in TCP/IP?", qs);
            Answer q5a1 = MakeAnswer(false, "Application Session Network Physical");
            Answer q5a2 = MakeAnswer(true, "Application Transport Internet Network");
            Answer q5a3 = MakeAnswer(false, "Presentation Transport DataLink Physical");
            Answer q5a4 = MakeAnswer(false, "Application Transport DataLink Network");
            AddAnswersToQuestion(q5, q5a1, q5a2, q5a3, q5a4);

            Question q6 = MakeQuestion("What does LAN stand for?", qs);
            Answer q6a1 = MakeAnswer(false, "Language Anual Network");
            Answer q6a2 = MakeAnswer(true, "Local Area Network");
            Answer q6a3 = MakeAnswer(false, "Local Address Network");
            Answer q6a4 = MakeAnswer(false, "Language Address Network");
            AddAnswersToQuestion(q6, q6a1, q6a2, q6a3, q6a4);

            Question q7 = MakeQuestion("What does WAN stand for?", qs);
            Answer q7a1 = MakeAnswer(false, "Wide Address Netwok");
            Answer q7a2 = MakeAnswer(true, "Wide Area Network");
            Answer q7a3 = MakeAnswer(false, "Wireless Area Network");
            Answer q7a4 = MakeAnswer(false, "Wireless Address Network");
            AddAnswersToQuestion(q7, q7a1, q7a2, q7a3, q7a4);

            Question q8 = MakeQuestion("What are the main features of OOP?", qs);
            Answer q8a1 = MakeAnswer(true, "Encapsulation, Polymorphism and Inheritance");
            Answer q8a2 = MakeAnswer(false, "Encapsulation, Interface and Compiler");
            Answer q8a3 = MakeAnswer(false, "Science, Computers and Electricity");
            Answer q8a4 = MakeAnswer(false, "Integration, Polymorphism and Modularisation");
            AddAnswersToQuestion(q8, q8a1, q8a2, q8a3, q8a4);

            Question q9 = MakeQuestion("What is Asynchronous Programming?", qs);
            Answer q9a1 = MakeAnswer(false, "Programming that uses threads to display an arbitrary number of messages in a random order");
            Answer q9a2 = MakeAnswer(false, "A means of programming in which a unit of work runs together with the main thread");
            Answer q9a3 = MakeAnswer(true, "A means of determining what the square root of a random number is when multiplied with the first seven prime numbers");
            Answer q9a4 = MakeAnswer(false, "A means of parrallel programming in which a unit of work runs seperately from the main application thread and notifies the calling thread of its complition failure or progress");
            AddAnswersToQuestion(q9, q9a1, q9a2, q9a3, q9a4);

            Question q10 = MakeQuestion("What does API stand for?", qs);
            Answer q10a1 = MakeAnswer(false, "Access Programming Interface");
            Answer q10a2 = MakeAnswer(true, "Application Programming Interface");
            Answer q10a3 = MakeAnswer(false, "Application Parrallel Interface");
            Answer q10a4 = MakeAnswer(false, "Asynchronous Parralell Interface");
            AddAnswersToQuestion(q10, q10a1, q10a2, q10a3, q10a4);

            Question q11 = MakeQuestion("What does SOAP stand for?", qs);
            Answer q11a1 = MakeAnswer(false, "Simple Operating Application Protocol");
            Answer q11a2 = MakeAnswer(false, "Simple Address Application Protocol");
            Answer q11a3 = MakeAnswer(false, "Sample Activity Operation Protocol");
            Answer q11a4 = MakeAnswer(true, "Simple Object Access Protocol");
            AddAnswersToQuestion(q11, q11a1, q11a2, q11a3, q11a4);

            Question q12 = MakeQuestion("What does JSON stand for?", qs);
            Answer q12a1 = MakeAnswer(false, "JavaScript Orientation Network");
            Answer q12a2 = MakeAnswer(false, "Java Object Name");
            Answer q12a3 = MakeAnswer(true, "JavaScript Object Notation");
            Answer q12a4 = MakeAnswer(false, "Java Object Notation");
            AddAnswersToQuestion(q12, q12a1, q12a2, q12a3, q12a4);

            Question q13 = MakeQuestion("What does ACID stand for?", qs);
            Answer q13a1 = MakeAnswer(false, "Application Concurrency Interface Data");
            Answer q13a2 = MakeAnswer(true, "Atomicity Consistency Isolation Durability");
            Answer q13a3 = MakeAnswer(false, "Atomic Consistency Integration Durability");
            Answer q13a4 = MakeAnswer(false, "Atomicy Concurrency Isolation Data");
            AddAnswersToQuestion(q13, q13a1, q13a2, q13a3, q13a4);

            Question q14 = MakeQuestion("What is CSRf(Cross-Site Request Forgery)?", qs);
            Answer q14a1 = MakeAnswer(false, "A user executing attacs on a web application in which they are authenticated");
            Answer q14a2 = MakeAnswer(true, "An attack that forces an end user to execute unwanted actions on a web application in which they're currently authenticated.");
            Answer q14a3 = MakeAnswer(false, "A user forging Money");
            Answer q14a4 = MakeAnswer(false, "A user forging IP address");
            AddAnswersToQuestion(q14, q14a1, q14a2, q14a3, q14a4);

            Question q15 = MakeQuestion("What does URL stand for?", qs);
            Answer q15a1 = MakeAnswer(true, "Uniform Resource Locator");
            Answer q15a2 = MakeAnswer(false, "Universal Serial Locator");
            Answer q15a3 = MakeAnswer(false, "United resource Language");
            Answer q15a4 = MakeAnswer(false, "United representation Layer");
            AddAnswersToQuestion(q15, q15a1, q15a2, q15a3, q15a4);

            Question q16 = MakeQuestion("What is the default port for HTTP?", qs);
            Answer q16a1 = MakeAnswer(false, "1996");
            Answer q16a2 = MakeAnswer(true, "80");
            Answer q16a3 = MakeAnswer(false, "50");
            Answer q16a4 = MakeAnswer(false, "69");
            AddAnswersToQuestion(q16, q16a1, q16a2, q16a3, q16a4);

            Question q17 = MakeQuestion("What is SALT in cryptography?", qs);
            Answer q17a1 = MakeAnswer(false, "A method of hacking databases that run on windows operating systems");
            Answer q17a2 = MakeAnswer(false, "A method of scripting to obtain passwords");
            Answer q17a3 = MakeAnswer(false, "An application that inserts unneccesarry lines in your code");
            Answer q17a4 = MakeAnswer(true, "A random data that is used as an additional input to a one-way funnction that hashes a password or passphrase.");
            AddAnswersToQuestion(q17, q17a1, q17a2, q17a3, q17a4);

            Question q18 = MakeQuestion("What does URI stand for?", qs);
            Answer q18a1 = MakeAnswer(false, "United Resource Interface");
            Answer q18a2 = MakeAnswer(true, "Uniform Resource Identifier");
            Answer q18a3 = MakeAnswer(false, "Uniform Representation Identifier");
            Answer q18a4 = MakeAnswer(false, "United Resource Identifier");
            AddAnswersToQuestion(q18, q18a1, q18a2, q18a3, q18a4);

            Question q19 = MakeQuestion("What is Client-Server architecture?", qs);
            Answer q19a1 = MakeAnswer(false, "A network architecture in which the client have the authority");
            Answer q19a2 = MakeAnswer(true, "A network architecture in which each computer or process on the network is either a client or a server");
            Answer q19a3 = MakeAnswer(false, "A network architecture in which a client can access the database directly");
            Answer q19a4 = MakeAnswer(false, "A network architecture in which the clients are the servers");
            AddAnswersToQuestion(q19, q19a1, q19a2, q19a3, q19a4);

            Question q20 = MakeQuestion("What does UDP stand for?", qs);
            Answer q20a1 = MakeAnswer(true, "User Datagram Protocol");
            Answer q20a2 = MakeAnswer(false, "User Dialog Protocol");
            Answer q20a3 = MakeAnswer(false, "United Datagram Protocol");
            Answer q20a4 = MakeAnswer(false, "User Data Program");
            AddAnswersToQuestion(q20, q20a1, q20a2, q20a3, q20a4);

            Question q21 = MakeQuestion("What does DNS stand for?", qs);
            Answer q21a1 = MakeAnswer(false, "Data Network Server");
            Answer q21a2 = MakeAnswer(false, "Domain Network Service");
            Answer q21a3 = MakeAnswer(true, "Domain Name System");
            Answer q21a4 = MakeAnswer(false, "Domain Name Service");
            AddAnswersToQuestion(q21, q21a1, q21a2, q21a3, q21a4);

            Question q22 = MakeQuestion("Which one is not a programming language?", qs);
            Answer q22a1 = MakeAnswer(false, "Java");
            Answer q22a2 = MakeAnswer(false, "C#");
            Answer q22a3 = MakeAnswer(false, "C++");
            Answer q22a4 = MakeAnswer(true, "HTML");
            AddAnswersToQuestion(q22, q22a1, q22a2, q22a3, q22a4);

            Question q23 = MakeQuestion("What is ADO.NET?", qs);
            Answer q23a1 = MakeAnswer(true, "A data access technology from the .NET framework");
            Answer q23a2 = MakeAnswer(false, "A protocol in TCP/IP");
            Answer q23a3 = MakeAnswer(false, "A technology for showing graphs");
            Answer q23a4 = MakeAnswer(false, "A technology for displaying information from the .net framework");
            AddAnswersToQuestion(q23, q23a1, q23a2, q23a3, q23a4);

            Question q24 = MakeQuestion("What is CSS(Cascading Style Sheets)?", qs);
            Answer q24a1 = MakeAnswer(false, "A protocol for TCP/IP");
            Answer q24a2 = MakeAnswer(false, "A data access technology from the .NET framework");
            Answer q24a3 = MakeAnswer(true, "A style sheet language used for describing the presentation of a document written in markup language");
            Answer q24a4 = MakeAnswer(false, "Is a protocol used to specify the position and colour of buttons on a webpage");
            AddAnswersToQuestion(q24, q24a1, q24a2, q24a3, q24a4);

            Question q25 = MakeQuestion("What does MVC stand for?", qs);
            Answer q25a1 = MakeAnswer(false, "Media Violence Cascade");
            Answer q25a2 = MakeAnswer(false, "Model View Cascade");
            Answer q25a3 = MakeAnswer(false, "Multy View Controller");
            Answer q25a4 = MakeAnswer(true, "Model View Controller");
            AddAnswersToQuestion(q25, q25a1, q25a2, q25a3, q25a4);

            Question q26 = MakeQuestion("What is a REST web service?", qs);
            Answer q26a1 = MakeAnswer(false, "Web service that calulates the amount of hours you need to sleep in order to rest properly");
            Answer q26a2 = MakeAnswer(false, "A protocol that allows users to swift between 12inch screens and 13inch screens according to need");
            Answer q26a3 = MakeAnswer(false, "Web service used when creating a Web Form to provide web functionalities with the help of the internet");
            Answer q26a4 = MakeAnswer(true, "A way of providing interoperatibility between computer systems on the Internet");
            AddAnswersToQuestion(q26, q26a1, q26a2, q26a3, q26a4);

            Question q27 = MakeQuestion("What does inheritance do?", qs);
            Answer q27a1 = MakeAnswer(false, "A software concept used in programming to show the relations between different classes");
            Answer q27a2 = MakeAnswer(false, "A protocol used for answering the most questions the fastest");
            Answer q27a3 = MakeAnswer(false, "A concept that allows certain classes to gain status and be more important than others");
            Answer q27a4 = MakeAnswer(true, "A way of passing attributes and methods from a base class to one or more subclasses");
            AddAnswersToQuestion(q27, q27a1, q27a2, q27a3, q27a4);

            Question q28 = MakeQuestion("What is an abstract class?", qs);
            Answer q28a1 = MakeAnswer(false, "A class that contains a method that returns the id of every object in the class even if they don't have one");
            Answer q28a2 = MakeAnswer(true, "A class that cannot be instantiated and requires subclasses to have the implemntation for its methods");
            Answer q28a3 = MakeAnswer(false, "A class that cannot be accesed from other classes unless they have a certain permission");
            Answer q28a4 = MakeAnswer(false, "A class that controlls all other classes");
            AddAnswersToQuestion(q28, q28a1, q28a2, q28a3, q28a4);

            Question q29 = MakeQuestion("What can you do to protect paswords stored in a database?", qs);
            Answer q29a1 = MakeAnswer(false, "Never store a password");
            Answer q29a2 = MakeAnswer(true, "You can hash and salt the password");
            Answer q29a3 = MakeAnswer(false, "You write them on paper and lock it in the safe");
            Answer q29a4 = MakeAnswer(false, "You password-protect your database");
            AddAnswersToQuestion(q29, q29a1, q29a2, q29a3, q29a4);

            Question q30 = MakeQuestion("What is TDD?", qs);
            Answer q30a1 = MakeAnswer(true, "Test Driven Development");
            Answer q30a2 = MakeAnswer(false, "Test Developing Data");
            Answer q30a3 = MakeAnswer(false, "Theoretical Data Development");
            Answer q30a4 = MakeAnswer(false, "Transfer Data Development");
            AddAnswersToQuestion(q30, q30a1, q30a2, q30a3, q30a4);

            Question q31 = MakeQuestion("What is a class?", qs);
            Answer q31a1 = MakeAnswer(false, "A room with teachers and students");
            Answer q31a2 = MakeAnswer(true, "A template for creating objects");
            Answer q31a3 = MakeAnswer(false, "A way to store data");
            Answer q31a4 = MakeAnswer(false, "A way to access a database");
            AddAnswersToQuestion(q31, q31a1, q31a2, q31a3, q31a4);

            Question q32 = MakeQuestion("What is the 'static void main(string[] args)' method used for?", qs);
            Answer q32a1 = MakeAnswer(false, "It's a method that sends you the text main");
            Answer q32a2 = MakeAnswer(false, "It's a method that every class have");
            Answer q32a3 = MakeAnswer(false, "It's a method that cannot be changed");
            Answer q32a4 = MakeAnswer(true, "It's where the program begins and end");
            AddAnswersToQuestion(q32, q32a1, q32a2, q32a3, q32a4);

            Question q33 = MakeQuestion("What is a method?", qs);
            Answer q33a1 = MakeAnswer(true, "A code block that contains a series of statements");
            Answer q33a2 = MakeAnswer(false, "A way to do something");
            Answer q33a3 = MakeAnswer(false, "Something that you use to create a class");
            Answer q33a4 = MakeAnswer(false, "What a class consist off");
            AddAnswersToQuestion(q33, q33a1, q33a2, q33a3, q33a4);

            Question q34 = MakeQuestion("What is a parameter?", qs);
            Answer q34a1 = MakeAnswer(false, "A return value");
            Answer q34a2 = MakeAnswer(true, "A value that is passed into a function");
            Answer q34a3 = MakeAnswer(false, "A method");
            Answer q34a4 = MakeAnswer(false, "A type of class");
            AddAnswersToQuestion(q34, q34a1, q34a2, q34a3, q34a4);

            Question q35 = MakeQuestion("Which part of this(public void printName(string name)) method is the signature?", qs);
            Answer q35a1 = MakeAnswer(true, "public void [printName]([string] name)");
            Answer q35a2 = MakeAnswer(false, "[public void printName(string name)]");
            Answer q35a3 = MakeAnswer(false, "public void printName[(string name)]");
            Answer q35a4 = MakeAnswer(false, "[public void printName](string name)");
            AddAnswersToQuestion(q35, q35a1, q35a2, q35a3, q35a4);

            Question q36 = MakeQuestion("What parameter types are there?", qs);
            Answer q36a1 = MakeAnswer(false, "Class and method");
            Answer q36a2 = MakeAnswer(false, "Primitive, objective and method");
            Answer q36a3 = MakeAnswer(false, "Primitive, objective and class");
            Answer q36a4 = MakeAnswer(true, "Primitive and objective");
            AddAnswersToQuestion(q36, q36a1, q36a2, q36a3, q36a4);

            Question q37 = MakeQuestion("What does a field do?", qs);
            Answer q37a1 = MakeAnswer(false, "Store methods for a class");
            Answer q37a2 = MakeAnswer(false, "Store Classes for a program");
            Answer q37a3 = MakeAnswer(true, "Store data for an object to use");
            Answer q37a4 = MakeAnswer(false, "Store crops for harvesting");
            AddAnswersToQuestion(q37, q37a1, q37a2, q37a3, q37a4);

            Question q38 = MakeQuestion("What is the purpose of the constructor?", qs);
            Answer q38a1 = MakeAnswer(false, "To create a class");
            Answer q38a2 = MakeAnswer(false, "To create methods");
            Answer q38a3 = MakeAnswer(false, "To store enums");
            Answer q38a4 = MakeAnswer(true, "To instanciate the object");
            AddAnswersToQuestion(q38, q38a1, q38a2, q38a3, q38a4);

            Question q39 = MakeQuestion("What does a mutator method do?", qs);
            Answer q39a1 = MakeAnswer(false, "Change a method other than itself");
            Answer q39a2 = MakeAnswer(false, "Change a class");
            Answer q39a3 = MakeAnswer(true, "Change the state of an object");
            Answer q39a4 = MakeAnswer(false, "Change the fields in a class");
            AddAnswersToQuestion(q39, q39a1, q39a2, q39a3, q39a4);

            Question q40 = MakeQuestion("What does a Accessor method do?", qs);
            Answer q40a1 = MakeAnswer(true, "Return implementation about the state of an object");
            Answer q40a2 = MakeAnswer(false, "Return the class");
            Answer q40a3 = MakeAnswer(false, "Return the method");
            Answer q40a4 = MakeAnswer(false, "Return the signature of a specific method");
            AddAnswersToQuestion(q40, q40a1, q40a2, q40a3, q40a4);

            Question q41 = MakeQuestion("What is a local variable?", qs);
            Answer q41a1 = MakeAnswer(false, "A variable declared and used within multiple classes");
            Answer q41a2 = MakeAnswer(false, "A variable declared and used within a single class");
            Answer q41a3 = MakeAnswer(true, "A variable declared and used within a single method");
            Answer q41a4 = MakeAnswer(false, "A variable declared and used within multiple methods");
            AddAnswersToQuestion(q41, q41a1, q41a2, q41a3, q41a4);

            Question q42 = MakeQuestion("What values does a boolean have?", qs);
            Answer q42a1 = MakeAnswer(true, "True and false");
            Answer q42a2 = MakeAnswer(false, "Any text");
            Answer q42a3 = MakeAnswer(false, "One or zero");
            Answer q42a4 = MakeAnswer(false, "Any number");
            AddAnswersToQuestion(q42, q42a1, q42a2, q42a3, q42a4);

            Question q43 = MakeQuestion("What does this method return(public void findNumber(int nr){number = nr};)?", qs);
            Answer q43a1 = MakeAnswer(false, "The number input into nr");
            Answer q43a2 = MakeAnswer(false, "false");
            Answer q43a3 = MakeAnswer(false, "true");
            Answer q43a4 = MakeAnswer(true, "Nothing");
            AddAnswersToQuestion(q43, q43a1, q43a2, q43a3, q43a4);

            Question q44 = MakeQuestion("What is deadlock?", qs);
            Answer q44a1 = MakeAnswer(false, "When you lose a method because it is considered dead/done");
            Answer q44a2 = MakeAnswer(false, "When an object is deleted it's called deadlock");
            Answer q44a3 = MakeAnswer(true, "When a process is waiting to use another process and vice versa");
            Answer q44a4 = MakeAnswer(false, "When you lock an object and never use it");
            AddAnswersToQuestion(q44, q44a1, q44a2, q44a3, q44a4);

            Question q45 = MakeQuestion("What is a distributed system?", qs);
            Answer q45a1 = MakeAnswer(false, "A system that distributes methods for classes");
            Answer q45a2 = MakeAnswer(true, "A model in which components located  on networked computers communicate and coordinate their actions by passing messages");
            Answer q45a3 = MakeAnswer(false, "A system that is in use to mae several classes work");
            Answer q45a4 = MakeAnswer(false, "A system that distributes variables to all the classes");
            AddAnswersToQuestion(q45, q45a1, q45a2, q45a3, q45a4);

            Question q46 = MakeQuestion("What types of visibility can the method have?", qs);
            Answer q46a1 = MakeAnswer(false, "Public, private and open");
            Answer q46a2 = MakeAnswer(false, "Public, private and secured");
            Answer q46a3 = MakeAnswer(true, "Public, private and protected");
            Answer q46a4 = MakeAnswer(false, "Public, private and safe");
            AddAnswersToQuestion(q4, q46a1, q46a2, q46a3, q46a4);

            Question q47 = MakeQuestion("Which of these method heads are written correctly?", qs);
            Answer q47a1 = MakeAnswer(false, "public getNumber()");
            Answer q47a2 = MakeAnswer(false, "public int getnumber");
            Answer q47a3 = MakeAnswer(true, "public int getNumber()");
            Answer q47a4 = MakeAnswer(false, "public int (getNumber)");
            AddAnswersToQuestion(q47, q47a1, q47a2, q47a3, q47a4);

            Question q48 = MakeQuestion("Which of these statements are correct?", qs);
            Answer q48a1 = MakeAnswer(true, "Low coupling and high cohesion is good");
            Answer q48a2 = MakeAnswer(false, "High coupling and low cohesion is good");
            Answer q48a3 = MakeAnswer(false, "Have no cohesion");
            Answer q48a4 = MakeAnswer(false, "Cohesion is a class");
            AddAnswersToQuestion(q48, q48a1, q48a2, q48a3, q48a4);

            Question q49 = MakeQuestion("What does this(pblic int setNumber(int nr){nr = 3; return nr}) method return?", qs);
            Answer q49a1 = MakeAnswer(true, "nr as a number");
            Answer q49a2 = MakeAnswer(false, "nr as text");
            Answer q49a3 = MakeAnswer(false, "nr as true");
            Answer q49a4 = MakeAnswer(false, "nr as a decimal");
            AddAnswersToQuestion(q49, q49a1, q49a2, q49a3, q49a4);

            Question q50 = MakeQuestion("What is the highest integer in 32-bit?", qs);
            Answer q50a1 = MakeAnswer(false, "9 999 999 999");
            Answer q50a2 = MakeAnswer(false, "1024 595 222");
            Answer q50a3 = MakeAnswer(false, "1 073 741 824");
            Answer q50a4 = MakeAnswer(true, "2 147 483 647");
            AddAnswersToQuestion(q50, q50a1, q50a2, q50a3, q50a4);

            return qs;

            //Question q5 = MakeQuestion("?", qs);
            //Answer q5a1 = MakeAnswer(false, "");
            //Answer q5a2 = MakeAnswer(false, "");
            //Answer q5a3 = MakeAnswer(false, "");
            //Answer q5a4 = MakeAnswer(false, "");
            //AddAnswersToQuestion(q5, q5a1, q5a2, q5a3, q5a4);
        }

        //creates and returns a questionset object
        public static QuestionSet MakeQuestionSet(string title, string description)
        {
            QuestionSet qs = new QuestionSet { Title = title, Description = description };
            qs.Questions = new List<Question>();
            return qs;
        }
        // creates a question object then adds it to a questionset and returns the object
        public static Question MakeQuestion(string text, QuestionSet qs)
        {
            Question q = new Question { Text = text };
            q.Answers = new List<Answer>();
            qs.Questions.Add(q);
            return q;
        }
        // creates an answer and returns the object
        public static Answer MakeAnswer(bool isValid, string text)
        {
            Answer a = new Answer { IsValid = isValid, Text = text };
            return a;
        }
        // adds four answers to a question that owns a list of answers
        public static void AddAnswersToQuestion(Question q, Answer a1, Answer a2, Answer a3, Answer a4)
        {
            q.Answers.Add(a1);
            q.Answers.Add(a2);
            q.Answers.Add(a3);
            q.Answers.Add(a4);
        }
    }
}
