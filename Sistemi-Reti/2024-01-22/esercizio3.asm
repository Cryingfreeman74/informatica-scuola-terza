;Marco Balducci 3H

name 'esercizio 3'

.model small

.data

X dw 3
W dw ?

.code
.startup

   MOV AX, X
   MOV BX, 5
   MUL BX
   MOV W, AX
   
   int 20h

.exit
END
