import { FieldValues, type Control} from "react-hook-form";
export interface FormInputProps{
    name: string;
    control?: Control;
    label?: string,
    error?: any
}