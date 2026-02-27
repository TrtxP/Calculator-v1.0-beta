# Calculator project with described principles of programming

## This code of project describes the basic principles of programming via creating a window application for calculation bacis math calculation.
## Here is a [directory of project file](./Calculator/Form1.cs)
## And here is a code lines of [clicking buttons](./Calculator/Form1.cs#L19-L151) where textBox is being changed by clicked button
## Code lines of [calculating expressions](./Calculator/Form1.cs#L171-L188) where via [try-catch block](./Calculator/Form1.cs#L173-L186) checking the correct input number variable for calculation of final result
## Code lines of [key pressing](./Calculator/Form1.cs#L161-L169) where event is being processed by KeyEventArgs class and [when key is pressed checking a condition if it was pressed already](./Calculator/Form1.cs#L163-L168) and processing calculation of numbers
## Code lines of [checking of changing text on calculator display](./Calculator/Form1.cs#L189-L200) where checking two conditions: [firstly checked if textBox was cleared or error was triggered](./Calculator/Form1.cs#L191) if yes just stop execution process of project, [next - processing checking condition on correct input text on textBox via pattern "\p{L}" of regular expression on checking the input any char letters](./Calculator/Form1.cs#L193) and if it was checked - [displaying the error of input char letter and stopping execution of the project](./Calculator/Form1.cs#L194-L199)
