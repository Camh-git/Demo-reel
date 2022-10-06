MOV R6, #2 ; minutes timer
MOV R5, #0 ; 10s of seconds timer
MOV R4, #0 ; seconds timer
MOV R7, #120 ; overall timer
loop1:
CALL oneSecDelay
DJNZ R7, loop1 ; 120 times - counting down from 120 to 0


 display0ctrl: ; control method for display0 representing seconds, sets the display to the appropriate value based on 
 ;the current value of R4, this is decremented when the one second delay method ends
  CJNE R4, #9, NOT_EQL01 ; if seconds counter is 9
  CLR p3.4
  CLR p3.3
  MOV p1, #00010000B; set display 0 to 9
  RET
  
 NOT_EQL01:;activated if counter is not 9
  CJNE R4, #8, NOT_EQL02 ; if seconds counter is 8
  CLR p3.4
  CLR p3.3
  MOV p1, #00000000B; set display 0 to 8
  RET

NOT_EQL02:;activated if counter is not 8
  CJNE R4, #7, NOT_EQL03 ; if seconds counter is 7
  CLR p3.4
  CLR p3.3
  MOV p1, #01011000B; set display 0 to 7
  RET

NOT_EQL03:;activated if counter is not 7
  CJNE R4, #6, NOT_EQL04 ; if seconds counter is 6
  CLR p3.4
  CLR p3.3
  MOV p1, #00000010B; set display 0 to 6
  RET

NOT_EQL04:;activated if counter is not 6
  CJNE R4, #5, NOT_EQL05 ; if seconds counter is 5
  CLR p3.4
  CLR p3.3
  MOV p1, #10011001B; set display 0 to 5
  RET

NOT_EQL05:;activated if counter is not 5
  CJNE R4, #4, NOT_EQL06 ; if seconds counter is 4
  CLR p3.4
  CLR p3.3
  MOV p1, #10011001B; set display 0 to 4
  RET

NOT_EQL06:;activated if counter is not 4
  CJNE R4, #3, NOT_EQL07 ; if seconds counter is 3
  CLR p3.4
  CLR p3.3
  MOV p1, #10110000B; set display 0 to 3
  RET

NOT_EQL07:;activated if counter is not 3
  CJNE R4, #2, NOT_EQL08 ; if seconds counter is 2
  CLR p3.4
  CLR p3.3
  MOV p1, #10100100B; set display 0 to 2
  RET

NOT_EQL08:;activated if counter is not 2
  CJNE R4, #1, NOT_EQL09 ; if seconds counter is 1
  CLR p3.4
  CLR p3.3
  MOV p1, #11111001B; set display 0 to 1
  RET

NOT_EQL09:;activated if counter is not 1
  CLR p3.4
  CLR p3.3
  MOV p1, #01000000B; set display 0 to 0
  MOV R4, #9
  DEC R5
  RET




 display1ctrl: ; control method for display1 representing 10s of seconds, sets the display to the appropriate value based on 
 ;the current value of R5, this is decremented when the seconds counter reaches 0 indicating the end of a 10 second block
 CJNE R5, #5, NOT_EQL11 ; if 10s timer is 5
  CLR p3.4
  SETB p3.3
  MOV p1, #00010010B; set display 1 to 5
  RET

  NOT_EQL11:;activated if counter is not 5
  CJNE R5, #4, NOT_EQL12 ; if 10s counter is 4
  CLR p3.4
  SETB p3.3
  MOV p1, #10011001B;set display 1 to 4
  RET

 NOT_EQL12:; activated if counter is not 4
  CJNE R5, #3, NOT_EQL13 ; if 10s counter is 3
  CLR p3.4
  SETB p3.3
  MOV p1, #10110000B;set display 1 to 3
  RET

 NOT_EQL13:; activated if timer is not 3
  CJNE R5, #2, NOT_EQL14 ; if 10s timer is 2
  CLR p3.4
  SETB p3.3
  MOV p1, #10100100B;set display 1 to 2
  RET

 NOT_EQL14:; activated if counter is not 2
  CJNE R5, #1, NOT_EQL15 ; if 10s counter is 1
  CLR p3.4
  SETB p3.3
  MOV p1, #11111001B;set display 1 to 1
  RET

 NOT_EQL15: ; activated if counter is not 1
  CLR p3.4
  SETB p3.3
  MOV p1, #01000000B;set display 1 to 0
  MOV R5, #5 ; resets the counter to allow it to count down 1 minute again
  DEC R6 ; decrements the minute counter so that  display 2 will know to show the right number
  RET



 display2ctrl: ; control method for display 0 wich represents minutes, sets it to the appropriate value based on 
 ;the current value of R6, this is decremented when the 10second counter reaches 0 indicating the end of a minute
 CJNE R6, #2, NOT_EQL21 ; if mins counter is 2
 EQL: ;if it is
 CLR p3.3 ;go to display 2
 SETB p3.4
 MOV p1, #10100100B ; make it show 2
 RET

 NOT_EQL21: ; if mins counteris not 2
  CJNE R6, #1, NOT_EQL22 ;if mins counter is 1
  CLR p3.3
  SETB p3.4
  MOV p1, #11111001B
  RET
 NOT_EQL22:;if mins timer is not 2 or 1 
 CLR p3.3
 SETB p3.4
 MOV p1, #01000000B
 RET




 using 0
       
MOV TMOD, #10H
       
      fiftyMsDelay:
CLR TR1 ; stop timer 1 (in case it was started in some other subroutine)
MOV TH1, #3CH
MOV TL1, #0B0H ; load 15,536 (3CB0H) into timer 1
SETB TR1 ; start timer 1
JNB TF1, $; repeat this line while timer 1 overflow flag is not set
CLR TF1; timer 1 overflow flag is set by hardware on transition from FFFFH - the flag must be reset by software
CLR TR1 ; stop timer 1
RET
       
MOV TMOD, #10H
       
      fiftyMsDelay0:
CLR TR1 ; stop timer 1 (in case it was started in some other subroutine)
MOV TH1, #3CH
MOV TL1, #0B0H ; load 15,536 (3CB0H) into timer 1
SETB TR1 ; start timer 1
JNB TF1, $; repeat this line while timer 1 overflow flag is not set
CLR TF1; timer 1 overflow flag is set by hardware on transition from FFFFH - the flag must be reset by software
CLR TR1 ; stop timer 1
CALL display0ctrl
RET

      fiftyMsDelay1:
CLR TR1 ; stop timer 1 (in case it was started in some other subroutine)
MOV TH1, #3CH
MOV TL1, #0B0H ; load 15,536 (3CB0H) into timer 1
SETB TR1 ; start timer 1
JNB TF1, $; repeat this line while timer 1 overflow flag is not set
CLR TF1; timer 1 overflow flag is set by hardware on transition from FFFFH - the flag must be reset by software
CLR TR1 ; stop timer 1
CALL display1ctrl
RET

      fiftyMsDelay2:
CLR TR1 ; stop timer 1 (in case it was started in some other subroutine)
MOV TH1, #3CH
MOV TL1, #0B0H ; load 15,536 (3CB0H) into timer 1
SETB TR1 ; start timer 1
JNB TF1, $; repeat this line while timer 1 overflow flag is not set
CLR TF1; timer 1 overflow flag is set by hardware on transition from FFFFH - the flag must be reset by software
CLR TR1 ; stop timer 1
CALL display2ctrl
RET
      oneSecDelay:
PUSH PSW
PUSH AR0 ; save processor status
MOV R0, #40 ; move 5 (in decimal) into R0
      loop2:
CALL fiftyMsDelay
CALL fiftyMsDelay0
CALL fiftyMsDelay1
CALL fiftyMsDelay2 ; call the 50 ms delay, and the control sections 
DJNZ R0, loop2 ; 5 times - resulting in a 1 second delay
POP AR0
POP PSW ; retrieve processor status
DEC R4 ;decrement seconds
DEC R7 ;decrement overall timer
RET

