import axios from 'axios'


export const bookAppointment = async(data:any) => {
    var res = await axios.post('http://localhost:5217/healthcare/book-appointment', data);
    return res.data;
}

export const getAllPatients = async() => {
    return await axios.get('http://localhost:5217/healthcare/getAllPatients');
}

export const getAllPractitioners = async() => {
    return await axios.get('http://localhost:5217/healthcare/getAllPractitioners');
}
