
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { deleteData, getData } from '../../../helpers/QuerryHelper';
import { Game } from '../../../models/Game';
import { useQueryClient, useQuery } from 'react-query';
import styled from 'styled-components';
import GamesEndpoint from '../../../endpoints/Games';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid2';
import { Link, Outlet } from 'react-router-dom';
import DeleteIcon from '@mui/icons-material/Delete';
import { ConfiramtionWindow } from '../../general/ConfiramtionWindow';
import { useState } from 'react';
const GridStyle = styled.div`
    background-color: gray;
    border: solid;
    border-color: #1976d2;
`;
const ButtonStyle = styled.div`
  display: flex;
  justify-content: flex-end;
`;



//rules of hooks
function  Games() {
  const [open, setOpen] = useState(false);
  const [confirmFunc, setConfirmFunc] = useState(async () =>{});
  const queryClient = useQueryClient();
  const {data, error } = useQuery({
    queryKey: [GamesEndpoint],
    queryFn:() => {

      var data = getData<Game[]>(GamesEndpoint);
      return data;
    }
  });
  
  if(error)
  {
    console.log(error);
  }
  const columns: GridColDef<Game[][number]>[] = [
    { field: 'id', headerName: 'ID', width: 150 },
    {
      field: 'name',
      headerName: 'Name',
      width: 150,
      editable: false,
    },
    {
      field: 'teams',
      headerName: 'Team count',
      width: 200,
      type: 'number',
      editable: false,
    },
    {
      field: 'maxPlayersInTeam',
      headerName: 'Max Players In Team',
      type: 'number',
      width: 200,
      editable: false,
    },
    {
      field: "action",
      headerName: "Action",
      sortable: false,
      width: 200,
      renderCell: (params) => {
        const onClick = async (e: any) => {
          setOpen(true);
          setConfirmFunc(async () => {
            e.stopPropagation();
            const res = await deleteData(params.row.id,GamesEndpoint);
           if(res) queryClient.invalidateQueries(GamesEndpoint);
          })
        };
        return <Button variant="contained" startIcon={<DeleteIcon />} onClick={onClick}>Delete</Button>;
      }
    }
  
  ];
  return (
    <>
    <Grid container spacing={2}>
      <Grid size = {{xs :12}}>
          <Outlet/>
      </Grid>
      <Grid size = {{xs :10}}/>
      <Grid size = {{xs :2}}>
        <ButtonStyle>
          <Link to="/games/create">
            <Button variant="contained">Create New</Button>
          </Link>
          
        </ButtonStyle>
      </Grid>
    </Grid>
    
    <GridStyle>
      <DataGrid
        rows={data?.data}
        columns={columns}
        disableRowSelectionOnClick />
    </GridStyle>
    <ConfiramtionWindow
  onConfirm={confirmFunc}
  open={open}
  onClose={() => setOpen(false)}
/>
    </>
    
  );
}

export default Games;