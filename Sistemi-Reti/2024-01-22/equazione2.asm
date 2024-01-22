;Marco Balducci 3H

name 'equazione 2'

.model small

.data

X DW 25
Y DW ?

.code
.startup

  MOV AX, X
  MOV BX, X
  MUL BX
  MUL BX; X^3
  MOV CX, 4
  MUL CX; 4X^3
  
  MOV CX, AX
  MOV AX, BX
  MUL BX; X^2
  MOV BX, 3
  MUL BX
  SUB CX, AX; 4X^3 - 3X^2
  
  MOV AX, X
  MOV BX, 2
  MUL BX
  ADD CX, AX; 4X^3 - 3X^2 + 2X
  
  ADD CX, 7; 4X^3 - 3X^2 + 2X + 7
  MOV Y, CX           
  
  INT 20h

.exit
END