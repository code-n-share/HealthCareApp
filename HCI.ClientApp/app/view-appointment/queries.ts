import axios from 'axios'

export async function getAllAppointments()  {
    const res = await axios.get('http://localhost:5217/HealthCare/getAllVisits');
    console.log(res);
    return res;
}