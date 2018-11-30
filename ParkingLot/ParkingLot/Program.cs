using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        /// <summary>
        /// Class for cars parked in parking lot
        /// </summary>
        public class ParkedCars
        {
            public string registrationNum;
            public string color;
            public int slot;

            public ParkedCars(string regsNum, string carColor, int carSlot)
            {
                registrationNum = regsNum;
                color = carColor;
                slot = carSlot;
            }
        }

        /// <summary>
        /// Parking lot class
        /// </summary>
        public class ParkingLot
        {
            private List<bool> availableSlots;
            private List<bool> allocatedSlots;

            //key is car registration number
            private Dictionary<string, int> CarRegistrationToSlot;

            //key is color
            private Dictionary<string, List<int>> CarColorToSlot;

            //key is parking slot
            private Dictionary<int, ParkedCars> CarsInParkingLot;

            public ParkingLot(int numSlots)
            {
                availableSlots = new List<bool>();
                allocatedSlots = new List<bool>();
                CarRegistrationToSlot = new Dictionary<string, int>();
                CarColorToSlot = new Dictionary<string, List<int>>();
                CarsInParkingLot = new Dictionary<int, ParkedCars>();

                for (int i = 0; i < numSlots; i++)
                {
                    availableSlots.Add(true);
                    allocatedSlots.Add(false);
                }

                Console.WriteLine("Created a parking lot with" + "  " + numSlots + "  " + "slots");
            }

            public void AllocateParkingSlot(string registrationNumber, string carColor)
            {
                int slotToAllocate = -1;
                for (int i = 0; i < availableSlots.Count; i++)
                {
                    if (availableSlots[i])
                    {
                        slotToAllocate = i + 1;
                        break;
                    }
                }

                if (slotToAllocate == -1)
                {
                    Console.WriteLine("Sorry, parking lot is full");
                }

                else
                {

                    UpdateParkingLotStatusAllocation(registrationNumber, carColor, slotToAllocate);
                }
            }

            private void UpdateParkingLotStatusAllocation(string registrationNumber, string carColor, int slotToAllocate)
            {
                availableSlots[slotToAllocate - 1] = false;
                allocatedSlots[slotToAllocate - 1] = true;

                if (!CarColorToSlot.ContainsKey(carColor))
                {
                    CarColorToSlot.Add(carColor, new List<int>());
                }

                CarColorToSlot[carColor].Add(slotToAllocate);
                CarRegistrationToSlot.Add(registrationNumber, slotToAllocate);
                ParkedCars car = new ParkedCars(registrationNumber, carColor, slotToAllocate);
                CarsInParkingLot.Add(slotToAllocate, car);
                Console.WriteLine("Allocated slot number:" + slotToAllocate);
            }

            public void LeaveParkingSlot(int slotNumber)
            {
                if (availableSlots[slotNumber - 1])
                {
                    Console.WriteLine(" Slot is already empty");
                    return;
                }

                else
                {
                    UpdateParkingLotStatusLeave(slotNumber);
                }
            }

            /// <summary>
            /// updates status of parking lot on leave
            /// </summary>
            /// <param name="slotNumber"></param>
            private void UpdateParkingLotStatusLeave(int slotNumber)
            {
                availableSlots[slotNumber - 1] = true;
                allocatedSlots[slotNumber - 1] = false;
                var carToBeRemoved = CarsInParkingLot[slotNumber];
                var carColor = carToBeRemoved.color;
                CarColorToSlot[carColor].Remove(slotNumber);
                CarRegistrationToSlot.Remove(carToBeRemoved.registrationNum);
                CarsInParkingLot.Remove(slotNumber);
                Console.WriteLine("Slot number " + slotNumber + "  is free.");
            }

            /// <summary>
            /// prints parking lot status
            /// </summary>
            public void ParkingLotStatus()
            {
                Console.WriteLine(" No.     Registration    Slot No.    Color");

                for (int i = 0; i < availableSlots.Count; i++)
                {
                    if (!availableSlots[i])
                    {
                        var carInParkingLot = CarsInParkingLot[i + 1];
                        PrintCarInParkingLot(carInParkingLot, i + 1);
                    }
                }
            }

            /// <summary>
            /// prints details about cars in the parking lot
            /// </summary>
            /// <param name="carInParkingLot"></param>
            /// <param name="slotNumber"></param>
            private void PrintCarInParkingLot(ParkedCars carInParkingLot, int slotNumber)
            {
                Console.WriteLine(slotNumber + "    " + carInParkingLot.registrationNum + "     " + slotNumber + "     " + carInParkingLot.color);
            }

            /// <summary>
            /// prints registration numbers for a given color
            /// </summary>
            /// <param name="color"></param>
            public void PrintRegistrationNumberOfCarsWithGivenColor(string color)
            {
                foreach (var entry in CarsInParkingLot.Values)
                {
                    if (entry.color == color)
                    {
                        Console.Write(entry.registrationNum + ",");
                    }
                }
            }

            /// <summary>
            /// prints slot number for a given registration number
            /// </summary>
            /// <param name="registrationNumber"></param>
            public void PrintSlotNumberForRegistrationNumber(string registrationNumber)
            {
                if (!CarRegistrationToSlot.ContainsKey(registrationNumber))
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    Console.WriteLine(CarRegistrationToSlot[registrationNumber]);
                }
            }

            /// <summary>
            /// prints slot number for cars with a given color
            /// </summary>
            /// <param name="color"></param>
            public void PrintSlotNumberForCarsWithGivenColor(string color)
            {
                if (!CarColorToSlot.ContainsKey(color) || CarColorToSlot[color].Count == 0)
                {
                    Console.WriteLine("Not found");
                }

                else
                {
                    foreach (var entry in CarColorToSlot[color])
                    {
                        Console.Write(entry + ",");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var inputToCreateParkingLot = Console.ReadLine().Split(" ");
            int numslots = Int32.Parse(inputToCreateParkingLot[1]);

            ParkingLot parkingLot = new ParkingLot(numslots);
            bool parkingLotOperate = true;

            //input driver
            //stop using Stop input
            while(parkingLotOperate)
            {
                var inputsForParkingLot1 = Console.ReadLine().Split(" ");
                if (inputsForParkingLot1[0] == "park")
                {
                    string registrationNumber = inputsForParkingLot1[1];
                    string color = inputsForParkingLot1[2];
                    parkingLot.AllocateParkingSlot(registrationNumber, color);
                }

                if (inputsForParkingLot1[0] == "leave")
                {
                    int slotNumberToLeave = Int32.Parse(inputsForParkingLot1[1]);
                    parkingLot.LeaveParkingSlot(slotNumberToLeave);
                }

                if (inputsForParkingLot1[0] == "Status")
                {
                    parkingLot.ParkingLotStatus();
                }

                if (inputsForParkingLot1[0] == "registration_numbers_for_cars_with_colour")
                {
                    string color = inputsForParkingLot1[1];
                    parkingLot.PrintRegistrationNumberOfCarsWithGivenColor(color);
                }

                if (inputsForParkingLot1[0] == "slot_numbers_for_cars_with_colour")
                {
                    string color = inputsForParkingLot1[1];
                    parkingLot.PrintSlotNumberForCarsWithGivenColor(color);
                }

                if (inputsForParkingLot1[0] == "slot_number_for_registration_number")
                {
                    string regsNum = inputsForParkingLot1[1];
                    parkingLot.PrintSlotNumberForRegistrationNumber(regsNum);
                }

                if (inputsForParkingLot1[0] == "Stop")
                {
                    parkingLotOperate = false;
                }
            }

        }
    }
}
