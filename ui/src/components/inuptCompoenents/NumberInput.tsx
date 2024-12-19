import { FormControl, FormHelperText, Input, InputLabel } from "@mui/material";
import { Controller } from "react-hook-form";
import { FormInputProps } from "./FormInputProps";

export const NumberInput = ({ name, control, label, error }: FormInputProps) => {
    return(
        <Controller
      name={name}
      control={control}
      render={({
        field
      }) => (
        <FormControl variant="standard">
                <InputLabel htmlFor={name}>{label}</InputLabel>
               <Input id={name} type="number" onChange={(e) => field.onChange(parseFloat(e.target.value) || 0)} error = {!!error}/> 
               <FormHelperText id={name+"-helper-text"}>{!!error?error.message:""}</FormHelperText>
        </FormControl>)}
    />
    );
}