import axios from 'axios';
import GameUrl from '../endpoints/BaseEndpoints';

const api = axios.create({
  baseURL: GameUrl,
  headers: {
    'Content-Type': 'application/json',
  },
});
export async function getData<T>(endpoint: string){
  return await api.get<T>(endpoint);
};
export async function postData<T>( object: T, endpoint: string){
  return await api.post<T>(endpoint, object);
};
export async function deleteData(id: string, endpoint: string){
  return await api.delete(endpoint,{params: {id}});
};


