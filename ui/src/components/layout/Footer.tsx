import Grid from '@mui/material/Grid2';
export function Footer() {
  return (
      <Grid container spacing={2}>
          <Grid size = {{xs :4}}>
              footer 1
          </Grid>
          <Grid size = {{xs :4}}>
              footer 2
          </Grid>
          <Grid size = {{xs :4}}>
              footer 3
          </Grid>
      </Grid>
  );
}

export default Footer;