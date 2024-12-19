import { FormControl, FormHelperText, Input, InputLabel } from "@mui/material";
import { Controller } from "react-hook-form";
import { FormInputProps } from "./FormInputProps";

export const TextInput: React.FC<FormInputProps> = ({ name, control, label, error }) => {
    return(
        <Controller
      name={name}
      control={control}
      render={({
        field: { onChange, value }
      }) => (
        <FormControl variant="standard">
                <InputLabel htmlFor={name}>{label}</InputLabel>
                <Input id={name} onChange={onChange} error = {!!error} value = {value}/>
                <FormHelperText id={name+"-helper-text"}>{!!error?error.message:""}</FormHelperText>
        </FormControl>)}
    />
    );
}