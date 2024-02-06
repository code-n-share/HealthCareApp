
"use client";

import React, { useEffect, useState } from 'react';
import { bookAppointment, getAllPatients, getAllPractitioners } from './action';
import { TextField, Select, SelectChangeEvent, MenuItem, Button } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { AppBar, Toolbar, Typography } from '@mui/material';

interface Patient {
  patientId: string,
  name: string
}

interface Practitioner {
  practitionerId: string,
  name: string
}

export default function BookAppointment() {
  const [date, setDate] = useState('');
  const [slotStartTimeHour, setSlotStartTimeHour] = useState('');
  const [slotStartTimeMin, setSlotStartTimeMin] = useState('');
  const [slotStartTimeAMPM, setSlotStartTimeAMPM] = useState('');
  const [slotEndtimeHour, setSlotEndTimeHour] = useState('');
  const [slotEndtimeMin, setSlotEndTimeMin] = useState('');
  const [slotEndtimeAMPM, setSlotEndTimeAMPM] = useState('');
  const [confirmationMessage, setConfirmationMessage] = useState('');

  const [selectedPatient, setSelectedPatient] = useState('');
  const [patients, setPatients] = useState<Patient[]>([]);
  const [selectedPractitioner, setSelectedPractitioner] = useState('');
  const [practitioners, setPractitioners] = useState<Practitioner[]>([]);

  useEffect(() => {
    const fetchOptions = async () => {

      const patientData = await getAllPatients();
      setPatients((patientData.data as Patient[]));

      const practitionerData = await getAllPractitioners();
      setPractitioners((practitionerData.data as Practitioner[]));

    };

    fetchOptions();
  }, []);

  const availableHours = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23]

  const handleFormSubmit = async (e: any) => {
    e.preventDefault();
    const appointmentId = await bookAppointment({
      "patientId": selectedPatient,
      "practitionerId": selectedPractitioner,
      "date": date,
      "slotStartTime": `${slotStartTimeHour}:${slotStartTimeMin} ${slotStartTimeAMPM}`,
      "slotEndTime": `${slotEndtimeHour}:${slotEndtimeMin} ${slotEndtimeAMPM}`
    });
    setConfirmationMessage(`Appointment booked successfully! Appointment ID: ${appointmentId}`);
  };

  const handlePatientChange = (event: SelectChangeEvent) => {
    setSelectedPatient(event.target.value);
  };

  const handlePractitionerChange = (event: any) => {
    setSelectedPractitioner(event.target.value);
  };

  return (
    <div className='flex min-h-screen flex-col items-center'>

      <AppBar className="border-b border-gray-300 bg-gray-200 dark:bg-zinc-800/30" position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            HCI HealthCare App
          </Typography>
        </Toolbar>
      </AppBar>

      <form onSubmit={handleFormSubmit} className='p-8'>
        <div className='mb-4'>
          <label className='block text-white-400 text-sm font-bold mb-2'>Patient Id:</label>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 250 }}
            className='form-control text-gray-700 text-m font-bold mb-2' id="pat-dropdown" value={selectedPatient} onChange={handlePatientChange}>
            <MenuItem value="">
              <em>Select...</em>
            </MenuItem>
            {patients.map((p) =>
              <MenuItem key={p.patientId} value={p.patientId}>{p.name}</MenuItem>
            )}
          </Select>
        </div>
        <div className='mb-4'>
          <label className='block text-gray-700 text-sm font-bold mb-2'>Practioner:</label>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 250 }}
            className='form-control text-gray-700 text-m font-bold mb-2' id="prac-dropdown" value={selectedPractitioner} onChange={handlePractitionerChange}>
            <MenuItem value="">
              <em>Select...</em>
            </MenuItem>
            {practitioners.map((p) =>
              <MenuItem key={p.practitionerId} value={p.practitionerId}>{p.name}</MenuItem>
            )}
          </Select>
        </div>
        <div className='mb-4'>
          <label className='block text-gray-700 text-sm font-bold mb-2'>Date:</label>
          <TextField style={{ color: 'white', backgroundColor: 'white', borderRadius: 5 }}
            type="date"
            variant='outlined'
            color='success'
            onChange={e => setDate(e.target.value)}
            value={date}
            fullWidth
            required
            sx={{ mb: 4 }}
          />
        </div>
        <div className='mb-4'>
          <label className='block text-gray-700 text-sm font-bold mb-2'>Slot StartTime:</label>
          <div>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 80 }}
            className='form-control text-gray-700 text-m font-bold mb-2' id="setime-dropdown" 
            value={slotStartTimeHour} 
            onChange={e => setSlotStartTimeHour(e.target.value)}
            >
            <MenuItem value="">
              <em>Select...</em>
            </MenuItem>
            {availableHours.map((h) =>
              <MenuItem key={h} value={h}>{h}</MenuItem>
            )}
          </Select>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 80, marginLeft:8 }}
            labelId="sst-min-label"
            id="sst-min"
            value={slotStartTimeMin}
            onChange={e => setSlotStartTimeMin(e.target.value)}
          >
            <MenuItem value={"00"}>00</MenuItem>
            <MenuItem value={"15"}>15</MenuItem>
            <MenuItem value={"30"}>30</MenuItem>
            <MenuItem value={"45"}>45</MenuItem>
          </Select>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 80, marginLeft:8 }}
            labelId="sst-ampm-label"
            id="sst-ampm"
            value={slotStartTimeAMPM}
            onChange={e => setSlotStartTimeAMPM(e.target.value)}
          >
            <MenuItem value={"AM"}>AM</MenuItem>
            <MenuItem value={"PM"}>PM</MenuItem>
          </Select>
          </div>
        </div>
        <div className='mb-4'>
          <label className='block text-gray-700 text-sm font-bold mb-2'>Slot EndTime:</label>
          <div>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 80 }}
            className='form-control text-gray-700 text-m font-bold mb-2' id="setime-dropdown" 
            value={slotEndtimeHour} 
            onChange={e => setSlotEndTimeHour(e.target.value)}
            >
            <MenuItem value="">
              <em>Select...</em>
            </MenuItem>
            {availableHours.map((h) =>
              <MenuItem key={h} value={h}>{h}</MenuItem>
            )}
          </Select>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 80, marginLeft:8 }}
            labelId="set-min-label"
            id="set-min"
            value={slotEndtimeMin}
            onChange={e => setSlotEndTimeMin(e.target.value)}
          >
            <MenuItem value={"00"}>00</MenuItem>
            <MenuItem value={"15"}>15</MenuItem>
            <MenuItem value={"30"}>30</MenuItem>
            <MenuItem value={"45"}>45</MenuItem>
          </Select>
          <Select style={{ color: 'gray', backgroundColor: 'white', borderRadius: 5, width: 80, marginLeft:8 }}
            labelId="set-ampm-label"
            id="set-ampm"
            value={slotEndtimeAMPM}
            onChange={e => setSlotEndTimeAMPM(e.target.value)}
          >
            <MenuItem value={"AM"}>AM</MenuItem>
            <MenuItem value={"PM"}>PM</MenuItem>
          </Select>
          </div>
          
        </div>
        {/* <div style={{ height: 32 }}></div> */}
        <Button variant="contained" endIcon={<SendIcon />} fullWidth
          type='submit'
          className='bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded'
        >
          Book Appointment
        </Button>
      </form>
      {confirmationMessage && <div style={{ minWidth: 300 }} className='mt-4 p-2 bg-green-200 text-green-800'>{confirmationMessage}</div>}
    </div>
  );
}