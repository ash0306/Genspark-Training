// Base class (Parent class)
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    introduce() {
        console.log(`Name:${this.name}, Age: ${this.age}`);
    }
}

// Derived class (Child class) inheriting from Person
class Student extends Person {
    constructor(name, age, grade) {
        super(name, age); 
        this.grade = grade;
    }

    // Method overriding for polymorphism
    introduce() {
        console.log(`Name:${this.name}, Age: ${this.age}, Grade:${this.grade}`);
    }

    // Encapsulation
    getGrade() {
        return this.grade;
    }

    setGrade(newGrade) {
        this.grade = newGrade;
    }
}

let student1 = new Student('Alice', 15, 9);
let person1 = new Person('Bob', 20);

// Encapsulation and Abstraction
student1.introduce();
person1.introduce();

// Polymorphism
let person2 = new Student('Charlie', 18, 11);
person2.introduce();

// Inheritance
console.log(student1.name);
console.log(person1.age);

// Encapsulation
console.log(student1.getGrade());
student1.setGrade(10);
console.log(student1.getGrade());
