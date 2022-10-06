



	
using 0

MOV TMOD, #10H; set up timer 1 as 16-bit interval timer

 
fiftyMsDelay:
CLR TR1 ; stop timer 1 (in case it was started in some other subroutine)
MOV TH1, #3CH
MOV TL1, #0B0H ; load 15,536 (3CB0H) into timer 1
SETB TR1 ; start timer 1
JNB TF1, $; repeat this line while timer 1 overflow flag is not set
CLR TF1; timer 1 overflow flag is set by hardware on transition from FFFFH - the flag must be reset by software
CLR TR1 ; stop timer 1
RET
 
oneSecDelay:
PUSH PSW
PUSH AR0 ; save processor status
MOV R0, #20 ; move 20 (in decimal) into R0
loop:
CALL fiftyMsDelay ; call the 50 ms delay
DJNZ R0, loop ; 20 times - resulting in a 1 second delay
POP AR0
POP PSW ; retrieve processor status
RET
