import { Button} from "@mui/material";
import { Box } from "@mui/material";
import { GameCreate, GameCreateSchema } from "../../../models/Game";
import { useMutation, useQueryClient } from "react-query";
import { Control, FieldValues, useForm } from "react-hook-form";
import { TextInput } from "../../inuptCompoenents/TextInput";
import { NumberInput } from "../../inuptCompoenents/NumberInput";
import GamesEndpoint from "../../../endpoints/Games";
import { postData } from "../../../helpers/QuerryHelper";
import { useNavigate } from "react-router-dom";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { styled } from '@mui/system';
const defaultValues = {
  name: "", 
  teams: 0,
  maxPlayersInTeam: 0
};
const CreateStyle = styled('div')(`
    background-color: gray;
    border: solid;
    border-color: #1976d2;
`);
type GameCreateType = z.infer<typeof GameCreateSchema>;
function CreateGame() {
  const { handleSubmit, control, reset, formState: state, register } = useForm<GameCreateType>({
    defaultValues: defaultValues,
    resolver: zodResolver(GameCreateSchema),
    mode: "onChange"
  });
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const {mutate } = useMutation({mutationFn:async (data: GameCreateType) => {
    const res = await postData<GameCreateType>(data, GamesEndpoint);
    if(res.status)
      queryClient.invalidateQueries({ queryKey: [GamesEndpoint] });
  }
    
  });
  
  
  const onSubmit = (data: GameCreateType) => {
    mutate(data)
    reset();
    navigate("/games");
  };
  return (  
    <CreateStyle>
      <Box 
        component="form"
        sx={{ '& > :not(style)': { m: 1 } }}
        noValidate
        autoComplete="off"
      >
        <TextInput name="name" control={(control as unknown) as Control<FieldValues>} error={state.errors.name} label="Name"/>
        <NumberInput  name="teams" control={(control as unknown) as Control<FieldValues>} error={state.errors.teams} label="Teams"/>
        <NumberInput  name="maxPlayersInTeam" control={(control as unknown) as Control<FieldValues>} error={state.errors.maxPlayersInTeam} label="Max Players"/> 
        <Button onClick={handleSubmit(onSubmit)} variant={"contained"}>
            Submit
        </Button>
      </Box>
    </CreateStyle>
    
  );
}

export default CreateGame;

