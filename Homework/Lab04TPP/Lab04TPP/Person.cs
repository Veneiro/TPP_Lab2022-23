using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    class Person {

        /// <summary>
        /// Attributes for Person
        /// </summary>
        private String firstName, surname;

        /// <summary>
        /// Property with the first name
        /// </summary>
        public String FirstName {
            get { return firstName; }
        }

        /// <summary>
        /// Property with the surname
        /// </summary>
        public String SurName {
            get { return surname; }
        }

        /// <summary>
        /// Property with the id number
        /// </summary>
        private string idNumber;
        public string IDNumber {
            get { return idNumber; }
        }

        /// <summary>
        /// To string for Person class
        /// </summary>
        /// <returns> A String formated </returns>
        public override String ToString() {
            return String.Format("{0} {1} with {2} ID number", firstName, surname, idNumber);
        }

        /// <summary>
        /// Constructor for the Person class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        public Person(String name, String surname, string idNumber) {
            this.firstName = name;
            this.surname = surname;
            this.idNumber = idNumber;
        }

        /// <summary>
        /// Default constructor for the Person class
        /// </summary>
        public Person() { }
        
        /// <summary>
        /// Equals method for the Person class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            Person person = obj as Person;
            if (person == null)
                return false;
            return this.IDNumber.Equals(person.IDNumber);
        }

        /// <summary>
        /// GetHashCode for the Person class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return this.IDNumber.GetHashCode();
        }
    }
}
