EESchema Schematic File Version 2
LIBS:power
LIBS:device
LIBS:switches
LIBS:relays
LIBS:motors
LIBS:transistors
LIBS:conn
LIBS:linear
LIBS:regul
LIBS:74xx
LIBS:cmos4000
LIBS:adc-dac
LIBS:memory
LIBS:xilinx
LIBS:microcontrollers
LIBS:dsp
LIBS:microchip
LIBS:analog_switches
LIBS:motorola
LIBS:texas
LIBS:intel
LIBS:audio
LIBS:interface
LIBS:digital-audio
LIBS:philips
LIBS:display
LIBS:cypress
LIBS:siliconi
LIBS:opto
LIBS:atmel
LIBS:contrib
LIBS:valves
LIBS:arduino
LIBS:arduino_dancer-cache
EELAYER 25 0
EELAYER END
$Descr A4 11693 8268
encoding utf-8
Sheet 1 1
Title ""
Date ""
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
$Comp
L Arduino_Uno_Shield XA?
U 1 1 5A8AB04E
P 5600 3250
F 0 "XA?" V 5700 3250 60  0000 C CNN
F 1 "Arduino_Uno_Shield" V 5500 3250 60  0000 C CNN
F 2 "" H 7400 7000 60  0001 C CNN
F 3 "" H 7400 7000 60  0001 C CNN
	1    5600 3250
	1    0    0    -1  
$EndComp
$Comp
L SW_DIP_x01 SW?
U 1 1 5A8AB32D
P 8000 1100
F 0 "SW?" H 8000 1250 50  0000 C CNN
F 1 "SW_DIP_x01" H 8000 950 50  0000 C CNN
F 2 "" H 8000 1100 50  0001 C CNN
F 3 "" H 8000 1100 50  0001 C CNN
	1    8000 1100
	1    0    0    -1  
$EndComp
$Comp
L SW_DIP_x01 SW?
U 1 1 5A9341F3
P 7400 1500
F 0 "SW?" H 7400 1650 50  0000 C CNN
F 1 "SW_DIP_x01" H 7400 1350 50  0000 C CNN
F 2 "" H 7400 1500 50  0001 C CNN
F 3 "" H 7400 1500 50  0001 C CNN
	1    7400 1500
	1    0    0    -1  
$EndComp
$Comp
L SW_DIP_x01 SW?
U 1 1 5A9342F0
P 7200 4850
F 0 "SW?" H 7200 5000 50  0000 C CNN
F 1 "SW_DIP_x01" H 7200 4700 50  0000 C CNN
F 2 "" H 7200 4850 50  0001 C CNN
F 3 "" H 7200 4850 50  0001 C CNN
	1    7200 4850
	1    0    0    -1  
$EndComp
$Comp
L SW_DIP_x01 SW?
U 1 1 5A9343A8
P 7850 5400
F 0 "SW?" H 7850 5550 50  0000 C CNN
F 1 "SW_DIP_x01" H 7850 5250 50  0000 C CNN
F 2 "" H 7850 5400 50  0001 C CNN
F 3 "" H 7850 5400 50  0001 C CNN
	1    7850 5400
	1    0    0    -1  
$EndComp
Wire Wire Line
	3200 1300 3200 3800
Wire Wire Line
	3200 1300 6550 1300
Wire Wire Line
	6550 1100 6550 1500
Wire Wire Line
	8300 2900 6900 2900
Wire Wire Line
	8300 1100 8300 2900
Wire Wire Line
	6550 1100 7700 1100
Wire Wire Line
	6550 1500 7100 1500
Connection ~ 6550 1300
Wire Wire Line
	7700 1500 7700 2800
Wire Wire Line
	7700 2800 6900 2800
Wire Wire Line
	3200 5200 6650 5200
Wire Wire Line
	6650 4850 6650 5400
Wire Wire Line
	6650 4850 6900 4850
Wire Wire Line
	7500 3100 7500 4850
Wire Wire Line
	6900 3100 7500 3100
Wire Wire Line
	6650 5400 7550 5400
Connection ~ 6650 5200
Wire Wire Line
	8150 5400 8300 5400
Wire Wire Line
	8300 5400 8300 3000
Wire Wire Line
	8300 3000 6900 3000
Wire Wire Line
	3200 3800 4300 3800
Wire Wire Line
	3200 5200 3200 3900
Wire Wire Line
	3200 3900 4300 3900
$EndSCHEMATC
