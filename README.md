# NT_Terminal

The NT Terminal application is a Microsoft Windows application developed with Visual Studio and written in C#.  It was designed to enable users of Signal Generators manufactured by Novatech Instruments to quickly and easily communicate with a Windows computer. Most Novatech Instruments' signal generators have a serial port and can be controlled by sending text characters from a computer to the signal generator.  

NT Terminal has fixed settings of 8 data bits, 1 stop bit, no parity and no hardware flow control.  It enables the user to enter the COM port number and the baud rate up to 256KBaud.  NT Terminal does not qualify the characters being sent to verify that they are appropriate for a specific instrument.  Because of this it can be used with all Novatech Instruments and could also be used with other devices.  Visual Studio was used to create an NT Terminal.msi file to make it easy to install NT Terminal on a computer by simply double clicking on the NT Terminal.msi icon.

In addition to provides the user an easy way to send them to the serial port of the computer, it also displays the response returned by the instrument connected to the serial port. If no instrument is connected it will display an error message.

Novatech Instruments has more capabile software for each signal generator instrument in sells, but this software also qualifies the commands based on the requirements of each instrument.  For this reason the more capable software has a version that is dedicated to each instrument and can only be used with one specific instrument.  The NT Terminal app can be used with all instruments manufactured by Novatech Instruments.
