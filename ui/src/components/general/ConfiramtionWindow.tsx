import { Button } from '@mui/material';
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
export interface ConfiramtionWindowProps {
    open: boolean;
    onConfirm:Promise<void>;
    onClose:()=> void;
  } 
  
  export function ConfiramtionWindow(props: ConfiramtionWindowProps) {
    const { onClose, onConfirm, open } = props;
  
    const handleClose = () => {
      onClose();      
    };
    const handleSubmit = async () => {
      await onConfirm;
      onClose();
    }
  
    return (
      <Dialog onClose={handleClose} open={open}>
        <DialogTitle>Are you sure?</DialogTitle>
        <Button onClick={handleSubmit}>Delete</Button>
        <Button onClick={handleClose}>Cancel</Button>
      </Dialog>
    );
  }