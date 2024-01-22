;Marco Balducci 3H

name 'equazione 1'

.model small

.data
   
   Y dw ?
   X dw 25
   Z dw 8
   W dw 10
   T dw 30
      
.code
.startup

   MOV AX, X
   ADD AX, X
   ADD AX, X
   ADD AX, X
   ADD AX, X
   ADD AX, X; y = 6x
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z
   SUB AX, Z; y = 6x - 9z
   ADD AX, W
   ADD AX, W
   ADD AX, W; y = 6x - 9z + 3w
   ADD AX, T
   ADD AX, T; y = 6x - 9z + 3w + 2t
   MOV BX, Z
   ADD BX, T; z + t
   SUB AX, BX
   SUB AX, BX
   SUB AX, BX
   SUB AX, BX; y = 6x - 9z + 3w + 2t - 4(z+t)
   MOV Y, AX
   
   int 20h
   
.exit
END