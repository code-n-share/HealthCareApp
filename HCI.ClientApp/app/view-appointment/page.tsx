"use client";

import { useEffect, useMemo, useState } from 'react';
import {
  MaterialReactTable,
  useMaterialReactTable,
  type MRT_ColumnDef,
} from 'material-react-table';

//Material UI Imports
import {
  Box,
  Button,
  ListItemIcon,
  MenuItem,
  Typography,
  lighten,
  AppBar,
  Toolbar
} from '@mui/material';

import { getAllAppointments } from './queries';

//example data type
type Visit = {
  visitId: string;
  patient:{
    "patientId": string;
    "name": string;
    "gender": string;
  },
  practitioner: {
    "practitionerId": string;
    "name": string;
    "type": string;
  },
  date: string;
  slotTime: string;
  status: string;
  feedback: string;
  createdAt: string;
};

const ViewAppointments = () => {

  const [data, setData] = useState<Visit[]>([]);

  useEffect(() => {
    const fetchOptions = async () => {

      const res = await getAllAppointments();
      setData((res.data as Visit[]));

    };

    fetchOptions();
  }, []);

  //should be memoized or stable
  const columns = useMemo<MRT_ColumnDef<Visit>[]>(
    () => [
      {
        accessorKey: 'visitId', 
        header: 'VisitId',
      },
      {
        accessorKey: 'patient.patientId', 
        header: 'PatientId',
      },
      {
        accessorKey: 'patient.name', 
        header: 'Patient Name',
      },
      {
        accessorKey: 'patient.gender', 
        header: 'Patient Gender',
      },
      {
        accessorKey: 'practitioner.practitionerId', 
        header: 'PractitionerId',
      },
      {
        accessorKey: 'practitioner.name', 
        header: 'Practitioner Name',
      },
      {
        accessorKey: 'practitioner.type', 
        header: 'Practitioner Type',
      },
      {
        accessorKey: 'date',
        header: 'Date',
      },
      {
        accessorKey: 'slotTime', 
        header: 'Slot',
      },
      {
        accessorKey: 'status',
        header: 'Status',
      },
      {
        accessorKey: 'feedback',
        header: 'Feedback',
      },
      {
        accessorKey: 'createdAt',
        header: 'CreatedAt',
      },
    ],
    [],
  );

  const table = useMaterialReactTable({
    columns,
    data,
    initialState: { columnVisibility: { 
      visitId: false, 
      feedback : false, 
      "patient.name":false,
      'patient.gender':false,
      'practitioner.practitionerId': false,
      'practitioner.name': false,
      'practitioner.type': false,
      createdAt: false
    } },
    renderDetailPanel: ({ row }) => (
      <Box
        sx={{
          // alignItems: 'center',
          display: 'flex',
          // justifyContent: 'space-around',
          left: '30px',
          maxWidth: '1000px',
          position: 'sticky',
          width: '100%',
        }}
      >
          <div className='mb-4'>
            <label className='block text-white-400 text-sm font-bold mb-2'>Visit Id: {row.getValue('visitId')}</label>
            <label className='block text-white-400 text-sm font-bold mb-2'>Patient Name : {row.getValue('patient.name')}</label>
            <label className='block text-white-400 text-sm font-bold mb-2'>Gender : {row.getValue('patient.gender')}</label>
            <label className='block text-white-400 text-sm font-bold mb-2'>Practitioner Name : {row.getValue('practitioner.name')} ( {row.getValue('practitioner.type')} | {row.getValue('practitioner.practitionerId')} )</label>
            <label className='block text-white-400 text-sm font-bold mb-2'>Feedback : {row.getValue('feedback')}</label>
            <label className='block text-white-400 text-sm font-bold mb-2'>Created At : {row.getValue('createdAt')}</label>
          </div>
      </Box>
    ),
  });

  return (
    <div>
      <AppBar className="border-b border-gray-300 bg-gray-200 dark:bg-zinc-800/30" position="static">
        <Toolbar>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            HCI HealthCare App
          </Typography>
        </Toolbar>
      </AppBar>
      <MaterialReactTable table={table} />
    </div>
  )
  

};

export default ViewAppointments;
