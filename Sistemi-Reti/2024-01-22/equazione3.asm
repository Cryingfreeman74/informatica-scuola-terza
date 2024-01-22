;Marco Balducci 3H

name 'equazione 3'

.model small

.data 

X dw 10
Y dw 15
res dw ?

.code
.startup
    
    ;(x + y)^2
    
    ;x^2
    MOV AX, X
    MUL AX
    
    ;y^2
    MOV CX, AX
    MOV AX, Y
    MUL AX
    
    ;2xy
    ADD CX, AX
    MOV AX, X
    MUL Y
    MOV BX, 2
    MUL BX
    ADD CX, AX
    
    ;x^2 + y^2 + 2xy
    MOV res, CX
    
.exit
END