import { Box, Button } from "@mui/material";
import { TextInput } from "../../../inuptCompoenents/TextInput";
import { Control, FieldValues, useForm } from "react-hook-form";
import { LoginSchema } from "../../../../models/Login";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
type LoginSchemaType = z.infer<typeof LoginSchema>;
interface LoginViewPorps{
  updateUser: any
}
const LoginView: React.FC<LoginViewPorps> = ({updateUser}) =>
{
    const { handleSubmit, control, formState: state } = useForm<LoginSchemaType>({
        resolver: zodResolver(LoginSchema),
        mode: "onChange"
      });
      const onSubmit = (data: LoginSchemaType) => {
        updateUser({login: data.login, isLogin: true});
      }
      
    return ( 
        <Box 
        component="form"
        sx={{ '& > :not(style)': { m: 1 } }}
        noValidate
        autoComplete="off"
      >
        <TextInput name="login" control={(control as unknown) as Control<FieldValues>} error={state.errors.login} label="Login"/>
        <TextInput name="password" control={(control as unknown) as Control<FieldValues>} error={state.errors.password} label="Password"/>
        <Button onClick={handleSubmit(onSubmit)} variant={"contained"}>
            Submit
        </Button>
        <Button variant={"contained"}>
            Register
        </Button>
      </Box>
      );
}
export default LoginView;