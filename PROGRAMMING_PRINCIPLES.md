# Calculator project with described principles of programming
---
## This code of project describes the basic principles of programming via creating a window application for calculation bacis math calculation.
## Here is a [directory of project file](./Calculator/Form1.cs)
## And here is a code lines of [clicking buttons](./Calculator/Form1.cs#L19-L151) where textBox is being changed by clicked button
## Code lines of [calculating expressions](./Calculator/Form1.cs#L171-L188) where via [try-catch block](./Calculator/Form1.cs#L173-L186) checking the correct input number variable for calculation of final result
## Code lines of [key pressing](./Calculator/Form1.cs#L161-L169) where event is being processed by KeyEventArgs class and [when key is pressed checking a condition if it was pressed already](./Calculator/Form1.cs#L163-L168) and processing calculation of numbers
## Code lines of [checking of changing text on calculator display](./Calculator/Form1.cs#L194-L205) where checking two conditions: [firstly checked if textBox was cleared or error was triggered](./Calculator/Form1.cs#L191) if yes just stop execution process of project, [next - processing checking condition on correct input text on textBox via pattern "\p{L}" of regular expression on checking the input any char letters](./Calculator/Form1.cs#L193) and if it was checked - [displaying the error of input char letter and stopping execution of the project](./Calculator/Form1.cs#L194-L199)
---
## Issues
---
1. Many of the [same methods with logic of button clicking](./Calculator/Form1.cs#L19-L151) that should be replaced by one general method for all clicking buttons with used instance of Button class
2. Written [two the mess boolean variables](./Calculator/Form1.cs#L14-L15) that should be replaced by "return" statement in checking certain conditions as in example of [checking the input a displayed text on textBox display](./Calculator/Form1.cs#L194-L205)
3. Displaying of [nonsence messages about warnings or errors](./Calculator/Form1.cs#L202) that should be removed by "return" statement for stopping execution of programm
---
